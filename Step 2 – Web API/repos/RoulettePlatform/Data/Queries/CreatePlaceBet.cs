using MediatR;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class CreatePlaceBet : IRequestHandler<CreatePlaceBetCommand, string>
    {
        /// <summary>
        /// Insert New PlaceBet into PlaceBets Table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(CreatePlaceBetCommand request, CancellationToken cancellationToken)
        {
            using (var con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Id", request.Id);
                    command.CommandText =
                        "INSERT INTO PlaceBets" +
                        "(Id) " +
                        "VALUES " +
                        "(@Id)";
                    int value = command.ExecuteNonQuery();
                }
            }

            return "new placebet is active";
        }
    }

    #region Properties

    /// <summary>
    /// Create Place Bet Command model
    /// </summary>
    public class CreatePlaceBetCommand : IRequest<string>
    {
        public string Id { get; set; }
    }

    #endregion

}
