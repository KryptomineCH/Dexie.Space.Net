# Dexie.Space.Net
This is a C# library for accessing the dexie.space API.

NOTE: Currently only the offers interface is implemented.

## Quickstart Guide
1. Install the package from NuGet by running Install-Package Dexie.Space.Net in the Package Manager Console in Visual Studio.

2. a) Call the Offers_Client.SendCustomMessage_Async method to send a custom message to the API:
```
string endpoint = ...;
string jsonPayload = ...;

string response = await Offers_Client.SendCustomMessage_Async(endpoint, jsonPayload);
```

2. b) Call any method in Offer_Client to use predefined metods:
```
string offer = "offer1qqz83wcsltt6wcmqvpsxygqqwc7hynr6hum6e0mnf72sn7uvvkpt68eyumkhqa9qmxpk8znenf...";
PostOffer_Response result = PostOffer_Sync(offer);
```

## Configuration
The following properties of the Offers_Client class can be configured to customize the behavior of the library:

`Offers_Client.UseTestnet`: Specifies whether the testnet or mainnet endpoint should be used. The default value is false (mainnet).

`Offers_Client.ProdURI`: The default API endpoint. The default value is "https://api.dexie.space/v1/".

`Offers_Client.TestURI`: The API endpoint for the testnet. The default value is "https://api-testnet.dexie.space/v1/".

`Offers_Client.RateLimitTimeSpan`: The timespan in which the maximum number of requests is counted. The default value is TimeSpan.FromSeconds(10), allowing for 50 requests per 10 seconds.

`Offers_Client.RateLimitMaxRequestCount`: The maximum number of requests allowed within the RateLimitTimeSpan. The default value is 49 requests.

## Error Handling
Errors may occur during the communication with the API. In such cases, the Offers_Client.SendCustomMessage_Async method will throw an exception. You can catch and handle these exceptions in your code.  
If the server is reachable but there is another error, the success variable in the response will be "false".

## Rate Limiting
The library implements rate limiting to prevent exceeding the API rate limit. 
The rate limit is set to 49 requests per 10 seconds by default, but can be configured using the Offers_Client.RateLimitTimeSpan and Offers_Client.RateLimitMaxRequestCount properties. 
Please note that 50 requests per 10 seconds is the configured rate limit by decie.space, so it is not recommended to change the default setting.
If the configured rate limit is reached, the Offers_Client.RatelimitReached property will be set to true and further requests will wait until the rate limit has been reset.
