namespace ScoreCardv2.Models
{
    public class FiveHundredViewModel : GameViewModel
    {
        public int Bidder { get; set; }
        public int?[] Suit { get; set; }
        public int?[] Bid { get; set; }
        public int?[] Defence { get; set; }
    }
}
