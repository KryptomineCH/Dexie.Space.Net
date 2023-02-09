using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dexie.Space.Net.Offers_NS.Objects_NS
{
    /// <summary>
    /// An enumeration that represents the sorting options for offers.
    /// </summary>
    public enum OfferSortOption
    {
        /// <summary>
        /// Sorts the offers by lowest price first.
        /// </summary>
        Price,

        /// <summary>
        /// Sorts the offers by highest price first.
        /// </summary>
        PriceDesc,

        /// <summary>
        /// Sorts the offers by recently completed offers first.
        /// </summary>
        DateCompleted,

        /// <summary>
        /// Sorts the offers by newly added offers first.
        /// </summary>
        DateFound
    }
}
