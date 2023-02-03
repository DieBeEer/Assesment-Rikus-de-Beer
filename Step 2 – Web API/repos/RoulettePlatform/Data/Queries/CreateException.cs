using MediatR;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace RoulettePlatform.Data.Queries
{
    public class CreateException : IRequestHandler<CreateExceptionCommand, string>
    {
        /// <summary>
        /// When exception is trown it writes to the database table GlobelException
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(CreateExceptionCommand request, CancellationToken cancellationToken)
        {
            using (var con = new SQLiteConnection("Data Source=./RouletteDB.db;Version=3"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.Parameters.AddWithValue("@ErrorMessage", request.ErrorMessage);
                    command.Parameters.AddWithValue("@StackTrace", request.StackTrace);
                    command.CommandText =
                        "INSERT INTO GlobalException " +
                        "(ErrorMessage," +
                        "StackTrace) " +
                        "VALUES " +
                        "(@ErrorMessage, " +
                        "@StackTrace)";
                    int value = command.ExecuteNonQuery();
                }
            }

            return "added successfully";
        }
    }

    #region Properties
    public class CreateExceptionCommand : IRequest<string>
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
    #endregion
}
