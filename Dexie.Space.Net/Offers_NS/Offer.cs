using System.Text.Json;

namespace Dexie.Space.Net.Offers_NS
{
    /// <summary>
    /// This class represents a serializable offer made on the DEXIE platform. 
    /// It contains information about the ID of the offer, its status, 
    /// the dates it was found and completed, the block index where it was spent, 
    /// the price, the tokens offered and requested, and the fees associated with the offer.
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// The unique ID of the offer
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The status of the offer (e.g. 4 for completed)
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// The date the offer was found
        /// </summary>
        public DateTime date_found { get; set; }

        /// <summary>
        /// The date the offer was completed
        /// </summary>
        public DateTime date_completed { get; set; }

        /// <summary>
        /// The date the offer became pending
        /// </summary>
        public DateTime date_pending { get; set; }

        /// <summary>
        /// The block index where the offer was spent
        /// </summary>
        public int spent_block_index { get; set; }

        /// <summary>
        /// The price of the offer
        /// </summary>
        public int price { get; set; }

        /// <summary>
        /// The tokens being offered as part of the offer
        /// </summary>
        public Token[] offered { get; set; }

        /// <summary>
        /// The tokens being requested as part of the offer
        /// </summary>
        public Token[] requested { get; set; }

        /// <summary>
        /// The fees associated with the offer
        /// </summary>
        public int fees { get; set; }
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
        public static Offer Load(string path)
        {
            if (!path.EndsWith(".dexieoffer"))
            {
                path += ".dexieoffer";
            }
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Offer>(json);
        }
    }
}
