using Dapper;
using MediatR;
using RoulettePlatform.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class GetPreviousSpins : IRequestHandler<GetPreviousSpinsQuery, List<BetResultsModel>>
    {
        /// <summary>
        /// Get previous spin bet result from BetResults table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<BetResultsModel>> Handle(GetPreviousSpinsQuery request, CancellationToken cancellationToken)
        {
            var list = new List<BetResultsModel>();

            using (IDbConnection con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                var result = con.Query<BetResultsModel>
                    ("SELECT BetResults.Placebet_Id," +
                            "BetResults.Id," +
                            "BetResults.Black," +
                            "BetResults.Red," +
                            "BetResults.Even," +
                            "BetResults.Odd," +
                            "BetResults.FirstHalf," +
                            "BetResults.SecondHalf," +
                            "BetResults.FirstTwelve," +
                            "BetResults.SecondTwelve," +
                            "BetResults.ThirdTwelve," +
                            "BetResults.FirstTwotoOne," +
                            "BetResults.SecondTwotoOne," +
                            "BetResults.ThirdTwotoOne," +
                            "BetResults.Number " +
                    "FROM BetResults"
                    , new DynamicParameters());

                list = result.ToList();
            }

            return list;

        }
    }

    #region Properties
    public class GetPreviousSpinsQuery : IRequest<List<BetResultsModel>>
    {
    }
    #endregion

}
