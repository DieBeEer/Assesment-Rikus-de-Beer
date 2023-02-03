using MediatR;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class UpdatePayoutStatus : IRequestHandler<UpdatePayoutStatusCommand, string>
    {
        /// <summary>
        /// updates the payout status by updating the Placebets table column IsBetPaid to 1
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(UpdatePayoutStatusCommand request, CancellationToken cancellationToken)
        {
            using (var con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Placebet_Id", request.PlacebetId);
                    command.CommandText =
                        "UPDATE Placebets " +
                        "SET IsBetPaid = 1 " +
                        "WHERE Id = @Placebet_Id";
                    int value = command.ExecuteNonQuery();
                }
            }
            return "done";
        }
    }

    #region Properties

    public class UpdatePayoutStatusCommand : IRequest<string>
    {
        public string PlacebetId { get; set; }
    }

    #endregion
}
