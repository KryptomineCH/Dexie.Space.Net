using System.Net.Http.Headers;

namespace Dexie.Space.Net.Offers_NS
{
    public static partial class Offers_Client
    {
        /// <summary>
        /// this client is used for the requests
        /// </summary>
        private static HttpClient _Client = new HttpClient();
        /// <summary>
        /// this boolean specifies wether the chia testnet or mainnet endpoint should be triggered.
        /// </summary>
        /// <remarks>
        /// switch between ProdURI and TestURI
        /// </remarks>
        public static bool UseTestnet { get; set; } = false;
        /// <summary>
        /// this is the default api endpoint
        /// </summary>
        /// <remarks>
        /// defaults to https://api.dexie.space/v1/ according to the documentation.
        /// </remarks>
        public static string ProdURI { get; set; } = "https://api.dexie.space/v1/";
        /// <summary>
        /// this is the api endpoint for the testnet.
        /// </summary>
        /// <remarks>
        /// default is https://api-testnet.dexie.space/v1/ according to the documentation
        /// </remarks>
        public static string TestURI { get; set; } = "https://api-testnet.dexie.space/v1/";
        /// <summary>
        /// this is the timespan in which the max requests is counted. <br/>
        /// it is not recommended to change this default value except, if dexie.space decides to update the rate limit in the future
        /// </summary>
        /// <remarks>
        /// The default is 50 requests per 10 seconds, which allows for some degree of burst
        /// </remarks>
        public static TimeSpan RateLimitTimeSpan { get; set; } = TimeSpan.FromSeconds(10);
        /// <summary>
        /// This is the amount of requests which can be taken withen the RateLimitTimeSpan
        /// it is not recommended to change this default value except, if dexie.space decides to update the rate limit in the future
        /// </summary>
        /// <remarks>
        /// The default is 50 requests per 10 seconds, which allows for some degree of burst <br/>
        /// The rate limit is decreased by one request (2%) in order to make sure there are no aliasing effects bringing the client into throtteling.
        /// </remarks>
        public static int RateLimitMaxRequestCount { get; set; } = 49;
        /// <summary>
        /// this queue is used to store the request times in order to keep track of the rate limits
        /// </summary>
        private static Queue<DateTime> UploadRateLimitList = new Queue<DateTime>();
        /// <summary>
        /// this will prevent race conditions when rate throtteling in multithreaded access
        /// </summary>
        private static object UploadRateLimitList_LockObject = new object();
        /// <summary>
        /// this variable indicates that the api rate limit has been reached and the maximum speed is beeing utilized
        /// </summary>
        public static bool RatelimitReached { get; private set; } = false;
        /// <summary>
        /// This function ensures that the api rate limit is not exceeded
        /// </summary>
        private static void AwaitRateLimit()
        {
            lock (UploadRateLimitList_LockObject)
            {
                // dequeue old (irrelevant entries)
                while (UploadRateLimitList.Any())
                {
                    DateTime requestTime;
                    if (UploadRateLimitList.TryPeek(out requestTime))
                    {
                        if (requestTime < DateTime.Now - RateLimitTimeSpan)
                        {
                            UploadRateLimitList.Dequeue();
                        }
                        else break;
                    }
                }
                // check if a rate limit applies
                if (UploadRateLimitList.Count >= RateLimitMaxRequestCount)
                {
                    // calculate sleep time
                    DateTime requestTime;
                    if (UploadRateLimitList.TryPeek(out requestTime))
                    {
                        TimeSpan sleep = requestTime - (DateTime.Now - RateLimitTimeSpan);
                        RatelimitReached = true;
                        Task.Delay(sleep).Wait();
                    }
                }
                UploadRateLimitList.Enqueue(DateTime.Now);
                RatelimitReached = false;
            }
        }
        /// <summary>
        /// This function sends a custom message to a specified endpoint using an HTTP POST request.
        /// </summary>
        /// <param name="endpoint">The endpoint to send the message to.</param>
        /// <param name="jsonPayload">The JSON payload to send with the message. Default value is "{}".</param>
        /// <returns>The response from the server as a string.</returns>
        public static async Task<string> SendCustomMessage_Async(string endpoint, string jsonPayload = " { } ")
        {
            AwaitRateLimit();
            string usedAddress = ProdURI;
            if (UseTestnet) usedAddress = TestURI;
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), usedAddress + endpoint))
            {
                request.Content = new StringContent(jsonPayload);
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await _Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(); ;
            }
        }
        /// <summary>
        /// with this function you can execute any request against the api. it is internally used by the library
        /// </summary>
        /// <param name="function"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string SendCustomMessage_Sync(string function, string json = " { } ")
        {
            Task<string> data = Task.Run(() => SendCustomMessage_Async(function, json));
            data.Wait();
            return data.Result;
        }
        /// <summary>
        /// This function retrieves the content of a url
        /// </summary>
        /// <param name="endpoint">The endpoint to request from.</param>
        /// <returns>The response from the server as a string.</returns>
        public static async Task<string> GetContent_Async(string endpoint)
        {
            AwaitRateLimit();
            string usedAddress = ProdURI;
            if (UseTestnet) usedAddress = TestURI;
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), usedAddress + endpoint))
            {
                var response = await _Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(); ;
            }
        }
        /// <summary>
        /// This function retrieves the content of a url
        /// </summary>
        /// <param name="endpoint">The endpoint to request from.</param>
        /// <returns>The response from the server as a string.</returns>
        public static async Task<string> GetContent_sync(string endpoint)
        {
            Task<string> data = Task.Run(() => GetContent_Async(endpoint));
            data.Wait();
            return data.Result;
        }
    }
}
