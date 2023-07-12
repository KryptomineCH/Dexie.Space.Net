using Dexie.Space.Net.Offers_NS.Objects_NS;

namespace Dexie.Space.Net.Offers_NS.Response_NS
{
    /// <summary>
    /// Represents the response of the API for the `GetOffer endpoint.
    /// </summary>
    public class GetOffer_Response
    {
        /// <summary>
        /// Indicates whether the API call was successful or not.
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// Represents an array of full offer objects.
        /// </summary>
        public Offer_Object? offer { get; set; }
        /// <summary>
        /// contains any error messages of the request
        /// </summary>
        public string? error { get; set; }
    }
}
