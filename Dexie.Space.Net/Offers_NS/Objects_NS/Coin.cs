namespace Dexie.Space.Net.Offers_NS.Objects_NS
{
    /// <summary>
    /// represents a coin in the chia namespace
    /// </summary>
    public class Coin
    {
        /// <summary>
        /// this coins id
        /// </summary>
        public string? id { get; set; }
        /// <summary>
        /// specified if the coin has been spnt or not (a coin may only be spent once)
        /// </summary>
        public bool spent { get; set; }
        /// <summary>
        /// the amount which the coin is worth
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// the timestamp when the coin was created/minted
        /// </summary>
        public ulong timestamp { get; set; }
        /// <summary>
        /// the coin id of this coin
        /// </summary>
        public string? puzzle_hash { get; set; }
        /// <summary>
        /// the coin id of the parent
        /// </summary>
        public string? parent_coin_info { get; set; }
        /// <summary>
        /// the block at which the coin was spent.
        /// if it wasnt, the value is 0
        /// </summary>
        public ulong spent_block_index { get; set; }
        /// <summary>
        /// the block at which the creation of the coin has been confirmed at
        /// </summary>
        public ulong confirmed_block_index { get; set; }
        /// <summary>
        /// The 'name' of a coin in this context appears to be a separate identifier or label associated with the coin.
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// the category / currency which the coin belongs to, eg "XCH" 
        /// </summary>
        public string? code { get; set; }
    }
}
