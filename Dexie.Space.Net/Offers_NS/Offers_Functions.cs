using System.Text.Json;

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
        public static async Task<PostOffer_Response> PostOffer_Async(string offer, bool dropOnly = false)
        {
            string endpoint = "/v1/offers";
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
        public static PostOffer_Response PostOffer_Sync(string offer, bool dropOnly = false)
        {
            Task<PostOffer_Response> data = Task.Run(() => PostOffer_Async(offer, dropOnly));
            data.Wait();
            return data.Result;
        }

    }
}
