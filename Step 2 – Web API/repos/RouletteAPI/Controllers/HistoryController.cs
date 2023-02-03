using Microsoft.AspNetCore.Mvc;
using RoulettePlatform.Interfaces;
using System.Threading.Tasks;

namespace RouletteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private readonly IHistoryInterface _historyInterface;
        public HistoryController(IHistoryInterface historyInterface) 
        { 
            _historyInterface = historyInterface;
            
        }

        [HttpGet, Route("GetPreviousSpinResult")]
        public Task<string> GetCustomerAsync()
        {
            return _historyInterface.GetPreviousSpinResult();
        }
    }
}
