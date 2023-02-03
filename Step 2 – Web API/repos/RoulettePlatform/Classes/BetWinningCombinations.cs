using RoulettePlatform.Data.Models;

namespace RoulettePlatform.Classes
{
    public static class BetWinningCombinations
    {
        public static (string BetType, decimal winnings, int totalPayout) GetValue(this CustomerBetModel single, BetResultsModel latestBetResult, int totalPayout)
        {
            if (single.Black == 1 && latestBetResult.Black == 1)
            {
                return ("Black", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.Red == 1 && latestBetResult.Red == 1)
            {
                return ("Red", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.Even == 1 && latestBetResult.Even == 1)
            {
                return ("Even", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.Odd == 1 && latestBetResult.Odd == 1)
            {
                return ("Odd", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.FirstHalf == 1 && latestBetResult.FirstHalf == 1)
            {
                return ("1-18", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.SecondHalf == 1 && latestBetResult.SecondHalf == 1)
            {
                return ("19-36", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.FirstTwelve == 1 && latestBetResult.FirstTwelve == 1)
            {
                return ("First12", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.SecondTwelve == 1 && latestBetResult.SecondTwelve == 1)
            {
                return ("Second12", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.ThirdTwelve == 1 && latestBetResult.ThirdTwelve == 1)
            {
                return ("Third12", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.FirstTwotoOne == 1 && latestBetResult.FirstTwotoOne == 1)
            {
                return ("1st 2-1", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.SecondTwotoOne == 1 && latestBetResult.SecondTwotoOne == 1)
            {
                return ("2nd 2-1", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.ThirdTwotoOne == 1 && latestBetResult.ThirdTwotoOne == 1)
            {
                return ("3rd 2-1", (single.BetAmount * 2), totalPayout += (single.BetAmount * 2));
            }
            if (single.Number == latestBetResult.Number)
            {
                return ("Number", single.NumberFull == 1 ? (single.BetAmount * 35) : (single.BetAmount * 17), totalPayout += single.NumberFull == 1 ? (single.BetAmount * 35) : (single.BetAmount * 17));
            }
            else
            {
                return ("no winnings", 0, totalPayout);
            }
        }
    }
}
