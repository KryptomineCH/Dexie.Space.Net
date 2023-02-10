using Dexie.Space.Net.Offers_NS.Objects_NS;

namespace Dexie.Space.Net.Offers_NS.Response_NS
{
    /// <summary>
    /// represents the response of the API which includes an offer
    /// </summary>
    public class PostOffer_Response
    {
        /// <summary>
        /// The success field represents whether the API call was successful or not
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// The id field represents the id of the offer
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The known field represents whether the offer is known or not
        /// </summary>
        public bool known { get; set; }

        /// <summary>
        /// The offer field is an instance of the Offer class
        /// </summary>
        public Offer_Object offer { get; set; }

        /// <summary>
        /// The error field represents an error message if there is any
        /// </summary>
        public string error { get; set; }
    }
}
