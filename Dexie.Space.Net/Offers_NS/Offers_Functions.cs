using System.Text.Json;
using Dexie.Space.Net.Offers_NS.Objects_NS;
using Dexie.Space.Net.Offers_NS.Response_NS;

namespace Dexie.Space.Net.Offers_NS
{
    public static partial class Offers_Client
    {
        /// <summary>
        /// This function is used to post an offer to the blockchain.
        /// </summary>
        /// <param name="offer">A string representation of the offer to be posted to the blockchain.</param>
        /// <param name="dropOnly">A boolean indicating whether the offer should be dropped after completion, or whether it should remain on the blockchain (default is `false`).</param>
        /// <returns>The result of posting the offer, as a string.</returns>
        public static async Task<PostOffer_Response?> PostOffer_Async(string offer, bool dropOnly = false)
        {
            string endpoint = "offers";
            string dropOnlyStr = dropOnly ? "true" : "false";
            string jsonPayload = "{\"offer\":\"" + offer + "\",\"drop_only\":\"" + dropOnlyStr + "\"}";
            string result = await SendCustomMessage_Async(endpoint, jsonPayload);
            return JsonSerializer.Deserialize<PostOffer_Response>(result);
        }
        /// <summary>
        /// This function is used to post an offer to the API, with the option to make it a drop-only offer. 
        /// The function sends a POST request to the API endpoint with the offer information and drop-only flag.
        /// </summary>
        /// <param name="offer">The offer information to be posted</param>
        /// <param name="dropOnly">Flag indicating if the offer should be a drop-only offer</param>
        /// <returns>The response from the API after posting the offer</returns>
        public static PostOffer_Response? PostOffer_Sync(string offer, bool dropOnly = false)
        {
            Task<PostOffer_Response?> data = Task.Run(() => PostOffer_Async(offer, dropOnly));
            PostOffer_Response? result = data.GetAwaiter().GetResult();
            return result;
        }
        /// <summary>
        /// Asynchronously retrieves offers based on the specified search parameters.
        /// </summary>
        /// <param name="rpc">An object representing the search parameters to use when retrieving offers.</param>
        /// <returns>A string representing the result of the search operation.</returns>
        public static async Task<GetOffers_Response?> GetOffers_Async(SearchOffer_RPC rpc)
        {
            var endpoint = "offers";
            string[] queryParams = rpc.BuildQueryParams();
            var queryString = string.Join("&", queryParams);
            var url = endpoint + "?" + queryString;
            string result = await GetContent_Async(url);
            return JsonSerializer.Deserialize<GetOffers_Response>(result);
        }
        /// <summary>
        /// This function is used to retrieve a list of offers from the API, based on the search criteria specified in the SearchOffer_RPC class.
        /// The function sends a GET request to the API endpoint with the search criteria encoded in the URL.
        /// </summary>
        /// <param name="rpc">The SearchOffer_RPC class containing the search criteria for the offers</param>
        /// <returns>The response from the API containing the list of offers matching the search criteria</returns>
        public static GetOffers_Response? GetOffers_Sync(SearchOffer_RPC rpc)
        {
            Task<GetOffers_Response?> data = Task.Run(() => GetOffers_Async(rpc));
            GetOffers_Response? result = data.GetAwaiter().GetResult();
            return result;
        }
        /// <summary>
        /// Asynchronously retrieves a specific offer based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the offer to retrieve.</param>
        /// <returns>An instance of the `GetOffer_Response` class representing the result of the retrieval operation.</returns>
        public static async Task<GetOffer_Response?> GetOffer_Async(string id)
        {
            var endpoint = $"offers/{id}";
            var url = endpoint;

            // Send a custom message to retrieve the offer data
            string result = await GetContent_Async(url);

            // Deserialize the result into an instance of the GetOffer_Response class
            return JsonSerializer.Deserialize<GetOffer_Response>(result);
        }
        /// <summary>
        /// Synchronously retrieves a specific offer based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the offer to retrieve.</param>
        /// <returns>An instance of the `GetOffer_Response` class representing the result of the retrieval operation.</returns>
        public static GetOffer_Response? GetOffer_Sync(string id)
        {
            Task<GetOffer_Response?> data = Task.Run(() => GetOffer_Async(id));
            GetOffer_Response? result = data.GetAwaiter().GetResult();
            return result;
        }
    }
}
