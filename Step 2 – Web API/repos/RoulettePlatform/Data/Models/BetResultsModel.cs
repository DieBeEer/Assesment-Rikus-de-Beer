namespace RoulettePlatform.Data.Models
{
    public class BetResultsModel
    {
        public string Placebet_Id { get; set; }
        public int Black { get; set; }
        public int Red { get; set; }
        public int Even { get; set; }
        public int Odd { get; set; }
        public int FirstHalf { get; set; }
        public int SecondHalf { get; set; }
        public int FirstTwelve { get; set; }
        public int SecondTwelve { get; set; }
        public int ThirdTwelve { get; set; }
        public int FirstTwotoOne { get; set; }
        public int SecondTwotoOne { get; set; }
        public int ThirdTwotoOne { get; set; }
        public int? Number { get; set; }
    }
}
