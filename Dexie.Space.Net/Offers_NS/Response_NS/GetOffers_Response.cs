using Dexie.Space.Net.Offers_NS.Objects_NS;

namespace Dexie.Space.Net.Offers_NS.Response_NS
{
    /// <summary>
    /// Represents the response of the API for the `GetOffers` endpoint.
    /// </summary>
    public class GetOffers_Response
    {
        /// <summary>
        /// Indicates whether the API call was successful or not.
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// Represents the number of found offers.
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// Represents the current page of the found offers.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Represents the number of offers per page.
        /// </summary>
        public int page_size { get; set; }

        /// <summary>
        /// Represents an array of full offer objects.
        /// </summary>
        public Offer[] offers { get; set; }
        public string? error { get; set; }
    }

}
