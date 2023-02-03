using System.Collections.Generic;

namespace RoulettePlatform.Data.ViewModels
{
    public class BetPayoutDetailsViewModel
    {
        public string CustomerIdentityNumber { get; set; }
        public decimal TotalPayout { get; set; }
        public List<BetDetailsViewModel> ListBetDetails
        {
            get; set;
        }
    }
}
