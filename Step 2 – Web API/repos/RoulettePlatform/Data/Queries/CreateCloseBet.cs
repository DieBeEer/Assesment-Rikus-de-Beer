using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class CreateCloseBet : IRequestHandler<CreateCloseBetCommand, string>
    {
        /// <summary>
        /// close the bet by updating the PlaceBets table set IsBetOpen to 0 for paramaeter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(CreateCloseBetCommand request, CancellationToken cancellationToken)
        {
            using (var con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Placebet_Id", request.PlacebetId);
                    command.CommandText = 
                        "UPDATE Placebets " +
                        "SET IsBetOpen = 0 " +
                        "WHERE Id = @Placebet_Id";
                    int value = command.ExecuteNonQuery();
                }
            }
            return "done";
        }
    }

    #region Properties
    public class CreateCloseBetCommand : IRequest<string>
    {
        public string PlacebetId { get; set; }
    }
    #endregion
}
