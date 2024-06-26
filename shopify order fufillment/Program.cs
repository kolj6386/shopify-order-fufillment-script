using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using DotNetEnv;

namespace ShopifyOrderFufillment
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static string shopName;
        // Make sure to give the admin API the appropriate permissions
        static string accessToken;
        static string shopUrl;
        // Has been tested with the latest version 2024-04 - This should last for a while
        static string apiVersion;
        // variant_id('s) of the item you want to look for and fufill 
        static long[] variantIdsToFufill;
        // How many orders you would like to look through per job 5,10,20,50 etc.
        static int ordersToReturn;
        static async Task Main()
        {
            // Load environment variables from .env file
            DotNetEnv.Env.Load();
            shopName = Env.GetString("SHOP_NAME");
            // Because DotNetEnv does not have a method to retreive data from arrays,
            // We will need to split our string, convert to long and then transform into an array.
            string variantIdsString = Env.GetString("VARIANT_IDS");
            variantIdsToFufill = variantIdsString.Split(',').Select(id => long.Parse(id.Trim())).ToArray();
            ordersToReturn = Env.GetInt("ORDER_NUMBER");
            shopUrl = $"https://{shopName}.myshopify.com";
            accessToken = Env.GetString("ACCESS_TOKEN");
            apiVersion = Env.GetString("API_VERSION");

            if (
                shopName == null ||
                variantIdsToFufill == null ||
                ordersToReturn == null ||
                shopUrl == null ||
                accessToken == null
                )
            {
                Console.WriteLine("Missing environment keys");
                return;
            }

            // Get our orders from Shopify 
            OrdersResponse shopifyOrderData = await getShopifyOrders();

            if (shopifyOrderData == null)
            {
                Console.WriteLine("No Shopify orders to display - Check function calls");
                return;
            }

            // Checking our order to see if it has a line item we want to fufill and returning it and the order id
            ShopifyFufillmentArray lineItemIdToFufill = CheckShopifyDataForOrdersToFufill(shopifyOrderData, variantIdsToFufill);

            if (lineItemIdToFufill == null)
            {
                Console.WriteLine("Order does not contain any line items that match the variant Id's we are looking for.");
                return;
            }

            // Getting our orders fufilment orders. Every order needs to be sent in with a fufilment order ID to be fufilled with the API.
            ShopifyFulfillmentOrdersDto fulfillmentOrderDto = await GetFufillmentOrders(lineItemIdToFufill.OrderId);

            if (fulfillmentOrderDto == null || fulfillmentOrderDto.FulfillmentOrders == null)
            {
                Console.WriteLine("Couldn't fetch fufillment orders");
            }

            // Fufilling our Orders.
            var response = await FufillShopifyFufillmentOrders(fulfillmentOrderDto, lineItemIdToFufill);
            Console.WriteLine($"fufillment response: {response}");

        }

        static async Task<OrdersResponse> getShopifyOrders()
        {
            try
            {
                client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);
                string shopifyOrderUrl = $"{shopUrl}/admin/api/{apiVersion}/orders.json?limit={ordersToReturn}";
                HttpResponseMessage response = await client.GetAsync(shopifyOrderUrl);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                OrdersResponse? shopifyOrders = JsonSerializer.Deserialize<OrdersResponse>(responseBody);

                if (shopifyOrders == null || shopifyOrders.Orders == null)
                {
                    Console.WriteLine("No orders found.");
                    return null;
                }

                return shopifyOrders;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        static ShopifyFufillmentArray CheckShopifyDataForOrdersToFufill(OrdersResponse shopifyOrderData, long[] variantIdsToFufill)
        {
            ShopifyFufillmentArray fufillmentData = new ShopifyFufillmentArray();
            fufillmentData.LineItems = new List<LineItem>();

            // Creating our array of line items to be fufilled with a order ID to send for fufillment
            foreach (Order order in shopifyOrderData.Orders)
            {
                if (order == null) { continue; }

                long orderId = order.Id;
                foreach (LineItem item in order.LineItems)
                {
                    if (Array.IndexOf(variantIdsToFufill, item.VariantId) != -1)
                    {
                        fufillmentData.OrderId = orderId;
                        fufillmentData.LineItems.Add(item);
                    }
                }
            }

            if (fufillmentData.LineItems.Count > 0)
            {
                return fufillmentData;
            }
            else
            {
                return null;
            }
        }
        static async Task<ShopifyFulfillmentOrdersDto> GetFufillmentOrders(long shopifyOrderId)
        {
            try
            {
                string fulfillmentOrderUrl = $"{shopUrl}/admin/api/{apiVersion}/orders/{shopifyOrderId}/fulfillment_orders.json";

                using (var request = new HttpRequestMessage(HttpMethod.Get, fulfillmentOrderUrl))
                {
                    request.Headers.Add("X-Shopify-Access-Token", accessToken);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var data = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    };

                    ShopifyFulfillmentOrdersDto? shopifyFulfillmentOrder = JsonSerializer.Deserialize<ShopifyFulfillmentOrdersDto>(data);

                    return shopifyFulfillmentOrder;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        static async Task<string> FufillShopifyFufillmentOrders(ShopifyFulfillmentOrdersDto fufillmentOrders, ShopifyFufillmentArray ShopifyOrder)
        {
            List<LineItemsToFufill> lineItemsToFufill = new List<LineItemsToFufill>();

            if (fufillmentOrders == null || ShopifyOrder == null)
            {
                return "No orders or fufillment orders passed in";
            }

            // Creating our order fufillment data for the payload
            foreach (ShopifyFulfillmentOrder ShopifyFulfillmentOrder in fufillmentOrders.FulfillmentOrders)
            {
                foreach (ShopifyFulfillmentOrderLineItem fufillmentLineItem in ShopifyFulfillmentOrder.LineItems)
                {
                    foreach (LineItem fufillmentOrderLineItem in ShopifyOrder.LineItems)
                    {
                        if (fufillmentLineItem.LineItemId == fufillmentOrderLineItem.Id)
                        {
                            LineItemsToFufill fufillmentItem = new LineItemsToFufill
                            {
                                id = fufillmentLineItem.Id,
                                quantity = 1
                            };
                            lineItemsToFufill.Add(fufillmentItem);
                        }
                    }
                }

                if (lineItemsToFufill == null)
                {
                    Console.WriteLine("nothing to fufill...");
                    continue;
                }

                var payload = new
                {
                    fulfillment = new
                    {
                        line_items_by_fulfillment_order = new[]
                        {
                            new
                            {
                                fulfillment_order_id = ShopifyFulfillmentOrder.Id,
                                fulfillment_order_line_items = lineItemsToFufill
                            }
                        },
                        message = string.Empty,
                        notify_customer = false,
                        origin_address = (object)null
                    }
                };

                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });

                // Now we have everything we need, we can get the order fufilled via the API 
                string fufillmentUrl = $"{shopUrl}/admin/api/{apiVersion}/fulfillments.json";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);
                var jsonPayLoad = JsonSerializer.Serialize(payload);
                var content = new StringContent(jsonPayLoad, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(fufillmentUrl, content);

                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Fulfillment created successfully: {responseBody}");
                        return responseBody;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create fulfillment. Status code: {response.StatusCode}");
                        Console.WriteLine($"Response content: {responseBody}");
                        return "Request failed - failed to fufill order";
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return "Request failed - failed to fulfill order";
                }

            }
            return "No matching line items found to fulfill.";
        }
    }

}


