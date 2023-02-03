using MediatR;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class CreateBetResult : IRequestHandler<CreateBetResultCommand, string>
    {
        /// <summary>
        /// Insert bet results into BetResults table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(CreateBetResultCommand request, CancellationToken cancellationToken)
        {
            using (var con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Placebet_Id", request.PlacebetId);
                    command.Parameters.AddWithValue("@Black", request.Black);
                    command.Parameters.AddWithValue("@Red", request.Red);
                    command.Parameters.AddWithValue("@Even", request.EvenNumber);
                    command.Parameters.AddWithValue("@Odd", request.OddNumber);
                    command.Parameters.AddWithValue("@FirstHalf", request.FirstHalf);
                    command.Parameters.AddWithValue("@SecondHalf", request.SecondHalf);
                    command.Parameters.AddWithValue("@FirstTwelve", request.FirstTwelve);
                    command.Parameters.AddWithValue("@SecondTwelve", request.SecondTwelve);
                    command.Parameters.AddWithValue("@ThirdTwelve", request.ThirdTwelve);
                    command.Parameters.AddWithValue("@FirstTwotoOne", request.FirstTwoToOne);
                    command.Parameters.AddWithValue("@SecondTwotoOne", request.SecondTwoToOne);
                    command.Parameters.AddWithValue("@ThirdTwotoOne", request.ThirdTwoToOne);
                    command.Parameters.AddWithValue("@Number", request.Number);
                    command.CommandText =
                        "INSERT INTO BetResults" +
                        "(Placebet_Id," +
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
                        "Number) " +
                        "VALUES " +
                        "(@Placebet_Id," +
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
                        "@Number)";
                    int value = command.ExecuteNonQuery();
                }
            }

            return "added successfully";
        }
    }

    #region Properties
    public class CreateBetResultCommand : IRequest<string>
    {
        public string PlacebetId { get; set; }
        public int Black { get; set; }
        public int Red { get; set; }
        public int FirstTwelve { get; set; }
        public int SecondTwelve { get; set; }
        public int ThirdTwelve { get; set; }
        public int FirstHalf { get; set; }
        public int SecondHalf { get; set; }
        public int OddNumber { get; set; }
        public int EvenNumber { get; set; }
        public int FirstTwoToOne { get; set; }
        public int SecondTwoToOne { get; set; }
        public int ThirdTwoToOne { get; set; }
        public int Number { get; set; }
    }
    #endregion

}
