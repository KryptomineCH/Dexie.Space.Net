using System.Text.Json;

namespace Dexie.Space.Net.Offers_NS.Objects_NS
{
    /// <summary>
    /// This class represents a serializable offer made on the DEXIE platform. 
    /// It contains information about the ID of the offer, its status, 
    /// the dates it was found and completed, the block index where it was spent, 
    /// the price, the tokens offered and requested, and the fees associated with the offer.
    /// </summary>
    public class Offer_Object
    {
        /// <summary>
        /// The unique ID of the offer
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// The status of the offer (e.g. 4 for completed)
        /// </summary>
        public OfferStatus status { get; set; }
        /// <summary>
        /// the offer string which might be saved to a file or pasted into the chia client
        /// </summary>
        public string? offer { get; set; }
        /// <summary>
        /// this dictionary holds the coin ids which are offered
        /// </summary>
        Dictionary<int, string>? offered_coins { get; set; }

        /// <summary>
        /// The date the offer was found
        /// </summary>
        public DateTime? date_found { get; set; }

        /// <summary>
        /// The date the offer was completed
        /// </summary>
        public DateTime? date_completed { get; set; }

        /// <summary>
        /// The date the offer became pending
        /// </summary>
        public DateTime? date_pending { get; set; }

        /// <summary>
        /// The block index where the offer was spent
        /// </summary>
        public ulong? spent_block_index { get; set; }

        /// <summary>
        /// The price of the offer
        /// </summary>
        public decimal? price { get; set; }
        /// <summary>
        /// an unknown value
        /// </summary>
        public decimal? previous_price { get; set; }

        /// <summary>
        /// The tokens being offered as part of the offer
        /// </summary>
        public dynamic[]? offered { get; set; }

        /// <summary>
        /// The tokens being requested as part of the offer
        /// </summary>
        public dynamic[]? requested { get; set; }

        /// <summary>
        /// The fees associated with the offer
        /// </summary>
        public int? mempool { get; set; }
        /// <summary>
        /// other offers related to this offer
        /// </summary>
        public dynamic[]? related_offers { get; set; }
        /// <summary>
        /// the coins related to this offer
        /// </summary>
        public Coin[]? coins { get; set; }
        /// <summary>
        /// wether there are currently counter offers
        /// </summary>
        public bool? has_bids { get; set; }
        /// <summary>
        /// Returns a JSON string representation of the Offer object.
        /// </summary>
        /// <returns>A JSON string representation of the Offer object.</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = false
            });
        }

        /// <summary>
        /// Saves the Offer object to disk as a JSON file.
        /// </summary>
        /// <param name="path">The file path to save the Offer object to.</param>
        public void Save(string path)
        {
            if (!path.EndsWith(".dexieoffer"))
            {
                path += ".dexieoffer";
            }
            File.WriteAllText(path, JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

        /// <summary>
        /// Loads an Offer object from disk.
        /// </summary>
        /// <param name="path">The file path to load the Offer object from.</param>
        /// <returns>The Offer object loaded from disk.</returns>
        public static Offer_Object? Load(string path)
        {
            if (!path.EndsWith(".dexieoffer"))
            {
                path += ".dexieoffer";
            }
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Offer_Object>(json);
        }
    }
}
