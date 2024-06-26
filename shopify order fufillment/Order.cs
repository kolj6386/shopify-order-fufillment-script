using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class OrdersResponse
{
    [JsonPropertyName("orders")]
    public List<Order> Orders { get; set; }
}
public class BillingAddress
{
    public string FirstName { get; set; }
    public string Address1 { get; set; }
    public string? Phone { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string LastName { get; set; }
    public string? Address2 { get; set; }
    public string? Company { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public string ProvinceCode { get; set; }
}

public class ClientDetails
{
    public string? AcceptLanguage { get; set; }
    public int? BrowserHeight { get; set; }
    public string BrowserIp { get; set; }
    public int? BrowserWidth { get; set; }
    public string? SessionHash { get; set; }
    public string UserAgent { get; set; }
}

public class CurrentSubtotalPriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class CurrentTotalDiscountsSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class CurrentTotalPriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class CurrentTotalTaxSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class Customer
{
    public long Id { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string State { get; set; }
    public string? Note { get; set; }
    public bool VerifiedEmail { get; set; }
    public string? MultipassIdentifier { get; set; }
    public bool TaxExempt { get; set; }
    public string? Phone { get; set; }
    public EmailMarketingConsent EmailMarketingConsent { get; set; }
    public string? SmsMarketingConsent { get; set; }
    public string Tags { get; set; }
    public string Currency { get; set; }
    public bool AcceptsMarketing { get; set; }
    public DateTime? AcceptsMarketingUpdatedAt { get; set; }
    public string MarketingOptInLevel { get; set; }
    public List<string> TaxExemptions { get; set; }
    public string AdminGraphqlApiId { get; set; }
    public DefaultAddress DefaultAddress { get; set; }
}

public class DefaultAddress
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Company { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string Zip { get; set; }
    public string? Phone { get; set; }
    public string Name { get; set; }
    public string ProvinceCode { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
    public bool Default { get; set; }
}

public class EmailMarketingConsent
{
    public string State { get; set; }
    public string OptInLevel { get; set; }
    public DateTime? ConsentUpdatedAt { get; set; }
}

public class LineItem
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    public string AdminGraphqlApiId { get; set; }
    public int FulfillableQuantity { get; set; }
    public string FulfillmentService { get; set; }
    public string? FulfillmentStatus { get; set; }
    public bool GiftCard { get; set; }
    public int Grams { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public PriceSet PriceSet { get; set; }
    public bool ProductExists { get; set; }
    public long? ProductId { get; set; }
    public List<object> Properties { get; set; }
    public int Quantity { get; set; }
    public bool RequiresShipping { get; set; }
    public string Sku { get; set; }
    public bool Taxable { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    public string TotalDiscount { get; set; }
    public TotalDiscountSet TotalDiscountSet { get; set; }
    [JsonPropertyName("variant_id")]
    public long? VariantId { get; set; }
    public string VariantInventoryManagement { get; set; }
    public string? VariantTitle { get; set; }
    public string Vendor { get; set; }
    public List<object> TaxLines { get; set; }
    public List<object> Duties { get; set; }
    public List<object> DiscountAllocations { get; set; }
}

public class Order
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    public string AdminGraphqlApiId { get; set; }
    public int AppId { get; set; }
    public string BrowserIp { get; set; }
    public bool BuyerAcceptsMarketing { get; set; }
    public string? CancelReason { get; set; }
    public DateTime? CancelledAt { get; set; }
    public string? CartToken { get; set; }
    public long? CheckoutId { get; set; }
    public string CheckoutToken { get; set; }
    public ClientDetails ClientDetails { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string? Company { get; set; }
    public string ConfirmationNumber { get; set; }
    public bool Confirmed { get; set; }
    public string ContactEmail { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Currency { get; set; }
    public string CurrentSubtotalPrice { get; set; }
    public CurrentSubtotalPriceSet CurrentSubtotalPriceSet { get; set; }
    public object? CurrentTotalAdditionalFeesSet { get; set; }
    public string CurrentTotalDiscounts { get; set; }
    public CurrentTotalDiscountsSet CurrentTotalDiscountsSet { get; set; }
    public object? CurrentTotalDutiesSet { get; set; }
    public string CurrentTotalPrice { get; set; }
    public CurrentTotalPriceSet CurrentTotalPriceSet { get; set; }
    public string CurrentTotalTax { get; set; }
    public CurrentTotalTaxSet CurrentTotalTaxSet { get; set; }
    public string CustomerLocale { get; set; }
    public long? DeviceId { get; set; }
    public List<object> DiscountCodes { get; set; }
    public string Email { get; set; }
    public bool EstimatedTaxes { get; set; }
    public string FinancialStatus { get; set; }
    public string? FulfillmentStatus { get; set; }
    public string? LandingSite { get; set; }
    public string? LandingSiteRef { get; set; }
    public long? LocationId { get; set; }
    public long? MerchantOfRecordAppId { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public List<object> NoteAttributes { get; set; }
    public int Number { get; set; }
    public int OrderNumber { get; set; }
    public string OrderStatusUrl { get; set; }
    public object? OriginalTotalAdditionalFeesSet { get; set; }
    public object? OriginalTotalDutiesSet { get; set; }
    public List<string> PaymentGatewayNames { get; set; }
    public string? Phone { get; set; }
    public string? PoNumber { get; set; }
    public string PresentmentCurrency { get; set; }
    public DateTime ProcessedAt { get; set; }
    public string Reference { get; set; }
    public string? ReferringSite { get; set; }
    public string SourceIdentifier { get; set; }
    public string SourceName { get; set; }
    public string? SourceUrl { get; set; }
    public string SubtotalPrice { get; set; }
    public SubtotalPriceSet SubtotalPriceSet { get; set; }
    public string Tags { get; set; }
    public bool TaxExempt { get; set; }
    public List<object> TaxLines { get; set; }
    public bool TaxesIncluded { get; set; }
    public bool Test { get; set; }
    public string Token { get; set; }
    public string TotalDiscounts { get; set; }
    public TotalDiscountsSet TotalDiscountsSet { get; set; }
    public string TotalLineItemsPrice { get; set; }
    public TotalLineItemsPriceSet TotalLineItemsPriceSet { get; set; }
    public string TotalOutstanding { get; set; }
    public string TotalPrice { get; set; }
    public TotalPriceSet TotalPriceSet { get; set; }
    public TotalShippingPriceSet TotalShippingPriceSet { get; set; }
    public string TotalTax { get; set; }
    public TotalTaxSet TotalTaxSet { get; set; }
    public string TotalTipReceived { get; set; }
    public int TotalWeight { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long? UserId { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public Customer Customer { get; set; }
    public List<object> DiscountApplications { get; set; }
    public List<object> Fulfillments { get; set; }
    [JsonPropertyName("line_items")]
    public List<LineItem> LineItems { get; set; }
    public object? PaymentTerms { get; set; }
    public List<object> Refunds { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public List<object> ShippingLines { get; set; }
}

public class PresentmentMoney
{
    public string Amount { get; set; }
    public string CurrencyCode { get; set; }
}

public class PriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class Root
{
    public List<Order> Orders { get; set; }
}

public class ShippingAddress
{
    public string FirstName { get; set; }
    public string Address1 { get; set; }
    public string? Phone { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string LastName { get; set; }
    public string? Address2 { get; set; }
    public string? Company { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public string ProvinceCode { get; set; }
}

public class ShopMoney
{
    public string Amount { get; set; }
    public string CurrencyCode { get; set; }
}

public class SubtotalPriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class TotalDiscountSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class TotalDiscountsSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class TotalLineItemsPriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class TotalPriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class TotalShippingPriceSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

public class TotalTaxSet
{
    public ShopMoney ShopMoney { get; set; }
    public PresentmentMoney PresentmentMoney { get; set; }
}

// Types for fufillment object

public class ShopifyFulfillmentOrdersDto
{
    [JsonPropertyName("fulfillment_orders")]
    public List<ShopifyFulfillmentOrder> FulfillmentOrders { get; set; }
}

public class ShopifyFulfillmentOrder
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("shop_id")]
    public long ShopId { get; set; }

    [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    [JsonPropertyName("assigned_location_id")]
    public long AssignedLocationId { get; set; }

    [JsonPropertyName("request_status")]
    public string RequestStatus { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("supported_actions")]
    public List<string> SupportedActions { get; set; }

    [JsonPropertyName("destination")]
    public ShopifyFulfillmentOrderAddress Destination { get; set; }

    [JsonPropertyName("line_items")]
    public List<ShopifyFulfillmentOrderLineItem> LineItems { get; set; }

    [JsonPropertyName("fulfill_at")]
    public string FulfillAt { get; set; }

    [JsonPropertyName("fulfill_by")]
    public string FulfillBy { get; set; }

    [JsonPropertyName("international_duties")]
    public object InternationalDuties { get; set; }

    [JsonPropertyName("fulfillment_holds")]
    public List<object> FulfillmentHolds { get; set; }

    [JsonPropertyName("delivery_method")]
    public ShopifyFulfillmentOrderDeliveryMethod DeliveryMethod { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("assigned_location")]
    public ShopifyFulfillmentOrderAssignedLocation AssignedLocation { get; set; }

    [JsonPropertyName("merchant_requests")]
    public List<object> MerchantRequests { get; set; }
}

public class ShopifyFulfillmentOrderAddress
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("address1")]
    public string Address1 { get; set; }

    [JsonPropertyName("address2")]
    public string Address2 { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("province")]
    public string Province { get; set; }

    [JsonPropertyName("zip")]
    public string Zip { get; set; }
}

public class ShopifyFulfillmentOrderLineItem
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("shop_id")]
    public long ShopId { get; set; }

    [JsonPropertyName("fulfillment_order_id")]
    public long FulfillmentOrderId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("line_item_id")]
    public long LineItemId { get; set; }

    [JsonPropertyName("inventory_item_id")]
    public long InventoryItemId { get; set; }

    [JsonPropertyName("fulfillable_quantity")]
    public int FulfillableQuantity { get; set; }

    [JsonPropertyName("variant_id")]
    public long VariantId { get; set; }
}

public class ShopifyFulfillmentOrderDeliveryMethod
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("method_type")]
    public string MethodType { get; set; }

    [JsonPropertyName("min_delivery_date_time")]
    public string MinDeliveryDateTime { get; set; }

    [JsonPropertyName("max_delivery_date_time")]
    public string MaxDeliveryDateTime { get; set; }
}

public class ShopifyFulfillmentOrderAssignedLocation
{
    [JsonPropertyName("address1")]
    public string Address1 { get; set; }

    [JsonPropertyName("address2")]
    public string Address2 { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("location_id")]
    public long LocationId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("province")]
    public string Province { get; set; }

    [JsonPropertyName("zip")]
    public string Zip { get; set; }
}

public class ShopifyFufillmentArray
{
    public long OrderId { get; set; }
    public List<LineItem>? LineItems { get; set; }
}

public class LineItemsToFufill
{
    public long? id { get; set; }
    public int quantity { get; set; }
}
