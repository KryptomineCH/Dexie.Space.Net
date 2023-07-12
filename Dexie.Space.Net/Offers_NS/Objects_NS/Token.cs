namespace Dexie.Space.Net.Offers_NS.Objects_NS
{
    /// <summary>
    /// This class represents a serializable token as part of an offer on the DEXIE platform. 
    /// It contains information about the ID, code, name, and amount of the token.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// The unique ID of the token
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// The code of the token (e.g. "SBX" for Spacebucks)
        /// </summary>
        public string? code { get; set; }

        /// <summary>
        /// The name of the token
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// The amount of the token involved in the offer
        /// </summary>
        public decimal amount { get; set; }
    }
}
