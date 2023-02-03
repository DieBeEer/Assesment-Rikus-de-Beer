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
    public class GetCustomerBet : IRequestHandler<GetCustomerBetQuery, List<CustomerBetModel>>
    {
        /// <summary>
        /// get list of customer bet
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<CustomerBetModel>> Handle(GetCustomerBetQuery request, CancellationToken cancellationToken)
        {
            var list = new List<CustomerBetModel>();

            using (IDbConnection con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                var result = con.Query<CustomerBetModel>
                    (
                    "SELECT " +
                    "Customer_Bet.Customer_Id, " +
                    "Customer_Bet.Placebet_Id, " +
                    "Customer_Bet.BetAmount, " +
                    "Customer_Bet.Black, " +
                    "Customer_Bet.Red, " +
                    "Customer_Bet.FirstTwelve, " +
                    "Customer_Bet.SecondTwelve, " +
                    "Customer_Bet.ThirdTwelve, " +
                    "Customer_Bet.FirstHalf, " +
                    "Customer_Bet.SecondHalf, " +
                    "Customer_Bet.Even, " +
                    "Customer_Bet.Odd, " +
                    "Customer_Bet.FirstTwotoOne, " +
                    "Customer_Bet.SecondTwotoOne, " +
                    "Customer_Bet.ThirdTwotoOne, " +
                    "Customer_Bet.NumberFull, " +
                    "Customer_Bet.NumberSplit, " +
                    "Customer_Bet.Number " +
                    "FROM Customer_Bet"
                    , new DynamicParameters());

                list = result?.ToList();
            }

            return list;

        }
    }

    #region Properties
    public class GetCustomerBetQuery : IRequest<List<CustomerBetModel>>
    {
    }
    #endregion

}
