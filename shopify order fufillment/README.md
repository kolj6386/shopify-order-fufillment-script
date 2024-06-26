# Shopify Order Fulfillment

This project is a C# application for automating order fulfillment in a Shopify store. It uses the Shopify Order & Fufilments API's to process and fulfill orders based on specific Id's in the .env files.

This is helpful if you have products like donations, or small upsells that are not physical items that do not get fufilled with an order and 
usually require manual fufillment in the admin, this can be time consuming if you have a lot of orders and can clog up your admin. 

This script is also my first attempt at writing a C# feel free to add in suggestions and I hope you put it to good use. You can run this from the console 
or modify it as needed. 


## Features

- Fetch orders from Shopify
- Identify line items to fulfill
- Create fulfillments for line order items via the Shopify API

## Requirements

- .NET 5.0 or later
- Shopify API Access Token
- DotNetEnv for environment variable management

## Setup

1. **Clone the repository:**
1. ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name

2. Restore dependencies
	```bash
	dotnet restore

3. Set up environment variables 
	SHOP_NAME="jesses-awesome-store" # This is the name of your store WITHOUT the myshopify.com affixed
	ACCESS_TOKEN="shpat_xxxxxxxxxxxxxx" # Need permissions - Orders: WRITE & READ, Fulfillment services: WRITE & READ
	VARIANT_IDS="40101051170881,40094016045121" # Need to store more than 1 option as a string with a comma seperator, single variant please use format "111111" no comma
	API_VERSION="2024-04" # This is the latest version of the API out currently so this will last you a while
	ORDER_NUMBER=10 # Number of orders you would like to look through per job 5,10,20,50 etc.

4. Run the application 
	```bash
	dotnet run
