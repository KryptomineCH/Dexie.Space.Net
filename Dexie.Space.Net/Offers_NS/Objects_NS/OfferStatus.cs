namespace Dexie.Space.Net.Offers_NS.Objects_NS
{
    /// <summary>
    /// An enumeration that represents the status of an offer.
    /// </summary>
    public enum OfferStatus
    {
        /// <summary>
        /// The offer is active and can be executed.
        /// </summary>
        Active = 0,

        /// <summary>
        /// The offer is pending and has not yet been executed.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The offer is pending cancellation and has not yet been cancelled.
        /// </summary>
        CancellingPending = 2,

        /// <summary>
        /// The offer has been cancelled.
        /// </summary>
        Cancelled = 3,

        /// <summary>
        /// The offer has been completed and cannot be modified or cancelled.
        /// </summary>
        Completed = 4,

        /// <summary>
        /// The offer status is unknown.
        /// </summary>
        Unknown = 5
    }
}
