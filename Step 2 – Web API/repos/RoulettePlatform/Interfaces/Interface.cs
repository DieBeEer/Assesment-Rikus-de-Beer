using RoulettePlatform.Classes.PlayVariations;
using System.Threading.Tasks;

namespace RoulettePlatform.Interfaces
{
    public interface IBettingInterface
    {
        Task<string> ExecutePlaceBet(Customer CustomerBet);
        Task<string> ExecuteSpin();
        Task<string> Payout();
    }

    public interface IHistoryInterface
    {
        Task<string> GetPreviousSpinResult();
    }
}
