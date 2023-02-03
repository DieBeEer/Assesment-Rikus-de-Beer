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
    public class GetBetResult : IRequestHandler<GetBetResultQuery, BetResultsModel>
    {
        /// <summary>
        /// Get a list from BetResults table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BetResultsModel> Handle(GetBetResultQuery request, CancellationToken cancellationToken)
        {
            var list = new BetResultsModel();

            using (IDbConnection con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                var result = con.Query<BetResultsModel>
                    (
                    "SELECT BetResults.Placebet_Id," +
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
                    "FROM BetResults  INNER JOIN PlaceBets  ON BetResults.Placebet_Id = PlaceBets.Id WHERE PlaceBets.IsBetPaid = 0"
                    , new DynamicParameters()
                    );

                list = result.Single();
            }

            return list;

        }
    }

    #region Properties
    public class GetBetResultQuery : IRequest<BetResultsModel>
    {
    }

    #endregion

}
