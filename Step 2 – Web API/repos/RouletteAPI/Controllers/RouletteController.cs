using Microsoft.AspNetCore.Mvc;
using RoulettePlatform.Classes.PlayVariations;
using RoulettePlatform.Interfaces;
using System.Threading.Tasks;

namespace RouletteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : Controller
    {
        private readonly IBettingInterface _placeBetInterface;

        public RouletteController(IBettingInterface placeBetInterface)
        {
            _placeBetInterface = placeBetInterface;
        }

        [HttpPost, Route("PlaceCustomerBet")]
        public async Task<string> PlaceCustomerBet([FromBody] Customer customer)
        {
            return await _placeBetInterface.ExecutePlaceBet(customer);
        }

        [HttpGet, Route("Spin")]
        public async Task<string> Spin()
        {
            return await _placeBetInterface.ExecuteSpin();
        }

        [HttpGet, Route("Payout")]
        public async Task<string> Payout()
        {
            var message = await _placeBetInterface.Payout();

            return message;
        }
    }
}
