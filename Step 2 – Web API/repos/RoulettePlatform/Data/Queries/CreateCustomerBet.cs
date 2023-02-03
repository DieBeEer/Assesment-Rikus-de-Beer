using MediatR;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class CreateCustomerBet : IRequestHandler<CreateCustomerBetCommand, string>
    {
        /// <summary>
        /// Insert Bet into CustomerBet table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(CreateCustomerBetCommand request, CancellationToken cancellationToken)
        {
            using (var con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Customer_Id", request.CustomerIdentityNumber);
                    command.Parameters.AddWithValue("@Placebet_Id", request.PlacebetId);
                    command.Parameters.AddWithValue("@BetAmount", request.BetAmount);
                    command.Parameters.AddWithValue("@Black", request.ColourBlack);
                    command.Parameters.AddWithValue("@Red", request.ColourRed);
                    command.Parameters.AddWithValue("@FirstTwelve", request.FirstTwelve);
                    command.Parameters.AddWithValue("@SecondTwelve", request.SecondTwelve);
                    command.Parameters.AddWithValue("@ThirdTwelve", request.ThirdTwelve);
                    command.Parameters.AddWithValue("@FirstHalf", request.FirstHalf);
                    command.Parameters.AddWithValue("@SecondHalf", request.SecondHalf);
                    command.Parameters.AddWithValue("@Even", request.EventNumber);
                    command.Parameters.AddWithValue("@Odd", request.OddNumber);
                    command.Parameters.AddWithValue("@FirstTwotoOne", request.FirstTwoToOne);
                    command.Parameters.AddWithValue("@SecondTwotoOne", request.SecondTwoToOne);
                    command.Parameters.AddWithValue("@ThirdTwotoOne", request.ThirdTwoToOne);
                    command.Parameters.AddWithValue("@NumberFull", request.NumberFull);
                    command.Parameters.AddWithValue("@NumberSplit", request.NumberSplit);
                    command.Parameters.AddWithValue("@Number", request.Number);
                    command.CommandText =
                        "INSERT INTO Customer_Bet" +
                        "(Customer_Id," +
                        "Placebet_Id," +
                        "BetAmount," +
                        "Black," +
                        "Red," +
                        "FirstTwelve," +
                        "SecondTwelve," +
                        "ThirdTwelve," +
                        "FirstHalf," +
                        "SecondHalf," +
                        "Even," +
                        "Odd," +
                        "FirstTwotoOne," +
                        "SecondTwotoOne," +
                        "ThirdTwotoOne," +
                        "NumberFull," +
                        "NumberSplit," +
                        "Number) " +
                        "VALUES " +
                        "(@Customer_Id," +
                        "@Placebet_Id," +
                        "@BetAmount," +
                        "@Black," +
                        "@Red," +
                        "@FirstTwelve," +
                        "@SecondTwelve," +
                        "@ThirdTwelve," +
                        "@FirstHalf," +
                        "@SecondHalf," +
                        "@Even," +
                        "@Odd," +
                        "@FirstTwotoOne," +
                        "@SecondTwotoOne," +
                        "@ThirdTwotoOne," +
                        "@NumberFull," +
                        "@NumberSplit," +
                        "@Number)";
                    int value = command.ExecuteNonQuery();
                }
            }

            return "added successfully";
        }
    }

    #region Properties
    public class CreateCustomerBetCommand : IRequest<string>
    {
        public string CustomerIdentityNumber { get; set; }
        public string PlacebetId { get; set; }
        public int BetAmount { get; set; }
        public int ColourBlack { get; set; }
        public int ColourRed { get; set; }
        public int FirstTwelve { get; set; }
        public int SecondTwelve { get; set; }
        public int ThirdTwelve { get; set; }
        public int FirstHalf { get; set; }
        public int SecondHalf { get; set; }
        public int OddNumber { get; set; }
        public int EventNumber { get; set; }
        public int FirstTwoToOne { get; set; }
        public int SecondTwoToOne { get; set; }
        public int ThirdTwoToOne { get; set; }
        public int Number { get; set; }
        public int NumberFull { get; set; }
        public int NumberSplit { get; set; }
    }
    #endregion
}
