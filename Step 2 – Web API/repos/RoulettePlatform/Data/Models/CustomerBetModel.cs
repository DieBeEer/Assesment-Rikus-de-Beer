namespace RoulettePlatform.Data.Models
{
    public class CustomerBetModel : BetResultsModel
    {
        public string Customer_Id { get; set; }
        public int BetAmount { get; set; }
        public int NumberFull { get; set; }
        public int NumberSplit { get; set; }
    }
}
