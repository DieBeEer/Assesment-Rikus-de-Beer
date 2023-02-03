using Dapper;
using MediatR;
using RoulettePlatform.Data.Models;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class GetOpenBet : IRequestHandler<GetOpenBetQuery, PlaceBetModel?>
    {
        /// <summary>
        /// Get open bet from PlaceBets table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PlaceBetModel?> Handle(GetOpenBetQuery request, CancellationToken cancellationToken)
        {
            var list = new PlaceBetModel();

            using (IDbConnection con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                var result = con.Query<PlaceBetModel>
                    (
                    "SELECT " +
                    "PlaceBets.Id, " +
                    "PlaceBets.IsBetOpen, " +
                    "PlaceBets.IsBetPaid " +
                    "FROM PlaceBets WHERE PlaceBets.IsBetOpen = 1 "
                    , new DynamicParameters());

                if (result.Count() > 0)
                {
                    list = result.Single();
                }
            }

            return list;

        }
    }

    #region Properties
    public class GetOpenBetQuery : IRequest<PlaceBetModel>
    {
    }
    #endregion

}
