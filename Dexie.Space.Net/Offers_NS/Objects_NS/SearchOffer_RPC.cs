using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dexie.Space.Net.Offers_NS.Objects_NS
{
    /// <summary>
    /// the rpc to search for offers
    /// </summary>
    public class SearchOffer_RPC
    {/// <summary>
     /// The status of the offers to include.
     /// </summary>
        public List<OfferStatus>? status { get; set; }

        /// <summary>
        /// The asset offered in the offers to include.
        /// </summary>
        public List<string>? offered { get; set; }

        /// <summary>
        /// The asset requested in the offers to include.
        /// </summary>
        public List<string>? requested { get; set; }

        /// <summary>
        /// The asset offered or requested in the offers to include.
        /// </summary>
        public List<string>? offered_or_requested { get; set; }

        /// <summary>
        /// The sort option for the offers.
        /// </summary>
        public OfferSortOption? sort { get; set; }

        /// <summary>
        /// Whether to output a lighter version of the offer data.
        /// </summary>
        public bool? compact { get; set; }

        /// <summary>
        /// Whether to include offers which request multiple assets.
        /// </summary>
        public bool? include_multiple_requested { get; set; }

        /// <summary>
        /// The page of offers to request.
        /// </summary>
        public int? page { get; set; }

        /// <summary>
        /// The number of offers to request per page.
        /// </summary>
        public int? page_size { get; set; }
        /// <summary>
        /// builds the query for the request
        /// </summary>
        /// <returns></returns>
        public string[] BuildQueryParams()
        {
            var queryParams = new List<string>();

            if (status != null && status.Count > 0)
            {
                queryParams.Add("status=" + string.Join(",", status.Select(x => (int)x)));
            }

            if (offered != null && offered.Count > 0)
            {
                queryParams.Add("offered=" + string.Join(",", offered));
            }

            if (requested != null && requested.Count > 0)
            {
                queryParams.Add("requested=" + string.Join(",", requested));
            }

            if (offered_or_requested != null && offered_or_requested.Count > 0)
            {
                queryParams.Add("offered_or_requested=" + string.Join(",", offered_or_requested));
            }

            if (sort != null)
            {
                queryParams.Add("sort=" + sort.ToString()!.ToLower());
            }

            if (compact != null)
            {
                queryParams.Add("compact="+ (bool) compact);
            }

            if (include_multiple_requested != null)
            {
                queryParams.Add("include_multiple_requested=true");
            }

            if (page != null && page > 0)
            {
                queryParams.Add("page=" + page);
            }

            if (page != null && page_size > 0)
            {
                queryParams.Add("page_size=" + page_size);
            }
            return queryParams.ToArray();
        }
    }
}
