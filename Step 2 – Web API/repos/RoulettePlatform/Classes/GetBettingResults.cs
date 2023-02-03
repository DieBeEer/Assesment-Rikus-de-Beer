using MediatR;
using RoulettePlatform.Classes.PlayVariations;
using RoulettePlatform.Data.Queries;
using RoulettePlatform.Data.Models;
using RoulettePlatform.Data.ViewModels;
using RoulettePlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoulettePlatform.Classes
{
    public class GetBettingResults : IBettingInterface
    {
        private readonly IMediator _mediator;

        public GetBettingResults(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> ExecutePlaceBet(Customer customerBet)
        {
            //check if there is a bet currently open
            var currentOpenBet = await _mediator.Send(new GetOpenBetQuery());

            var placeBetId = currentOpenBet.id == null ? Guid.NewGuid().ToString() : currentOpenBet.id;

            //if there is no current bet open , open a new bet
            if (currentOpenBet.id == null)
                await _mediator.Send(new CreatePlaceBetCommand { Id = placeBetId.ToString() });

            List<Task<string>> tasks = new();

            //create the customer bet for the new open bet
            if (customerBet.colourBet.Black > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.colourBet.Black,
                    ColourBlack = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.colourBet.Red > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.colourBet.Red,
                    ColourRed = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.evenOddBet.EvenBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.evenOddBet.EvenBet,
                    EventNumber = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.evenOddBet.OddBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.evenOddBet.OddBet,
                    OddNumber = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.halfBet.FirstHalfBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.halfBet.FirstHalfBet,
                    FirstHalf = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.halfBet.SecondHalfBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.halfBet.FirstHalfBet,
                    FirstHalf = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.partitionBet.FirstPartition > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.halfBet.FirstHalfBet,
                    FirstHalf = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.partitionBet.SecondPartition > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.partitionBet.SecondPartition,
                    SecondTwelve = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.partitionBet.ThirdPartition > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.partitionBet.ThirdPartition,
                    ThirdTwelve = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.twotoOneBet.FirstTwotoOne > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.twotoOneBet.FirstTwotoOne,
                    FirstTwoToOne = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.twotoOneBet.SecondTwotoOne > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.twotoOneBet.SecondTwotoOne,
                    SecondTwoToOne = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.twotoOneBet.ThirdTwotoOne > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                {
                    BetAmount = (int)customerBet.twotoOneBet.ThirdTwotoOne,
                    ThirdTwoToOne = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            foreach (var value in customerBet.numberBets)
            {
                if (value.NumberSplit == 1)
                {
                    tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                    {
                        BetAmount = (int)value.Value,
                        Number = (int)value.Number,
                        NumberSplit = 1,
                        CustomerIdentityNumber = customerBet.IdentityNumber,
                        PlacebetId = placeBetId
                    })));
                }
                if (value.NumberSplit == 0)
                {
                    tasks.Add(Task.Run(() => _mediator.Send(new CreateCustomerBetCommand
                    {
                        BetAmount = (int)value.Value,
                        Number = (int)value.Number,
                        NumberFull = 1,
                        CustomerIdentityNumber = customerBet.IdentityNumber,
                        PlacebetId = placeBetId
                    })));
                }
            }

            //await Task.WhenAll(tasks);
            await Task.WhenAll(tasks);

            return JsonSerializer.Serialize(new PlaceBetDetailsViewModel { CustomerIdentityNumber = customerBet.IdentityNumber, PlacBetId = placeBetId });
        }

        public async Task<string> ExecuteSpin()
        {
            var openBet = await _mediator.Send(new GetOpenBetQuery());

            int[] blackNumbers = new int[18] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
            int[] redNumbers = new int[18] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };

            Random r = new Random();
            int randomNumber = r.Next(0, 37);

            var betResult = new BetResultsModel
            {
                Placebet_Id = openBet.id,
                Black = blackNumbers.Any(x => x == randomNumber) ? 1 : 0,
                Red = redNumbers.Any(x => x == randomNumber) ? 1 : 0,
                Even = randomNumber % 2 == 0 ? 1 : 0,
                Odd = randomNumber % 2 == 0 ? 0 : 1,
                FirstHalf = randomNumber < 19 ? 1 : 0,
                SecondHalf = randomNumber > 18 ? 1 : 0,
                FirstTwelve = randomNumber <= 12 ? 1 : 0,
                SecondTwelve = randomNumber > 12 && randomNumber <= 24 ? 1 : 0,
                ThirdTwelve = randomNumber > 24 ? 1 : 0,
                FirstTwotoOne = randomNumber % 3 == 1 ? 1 : 0,
                SecondTwotoOne = randomNumber % 3 == 2 ? 1 : 0,
                ThirdTwotoOne = randomNumber % 3 == 0 && randomNumber != 0 ? 1 : 0,
                Number = randomNumber
            };

            await _mediator.Send(new CreateBetResultCommand
            {
                PlacebetId = betResult.Placebet_Id,
                Black = betResult.Black,
                Red = betResult.Red,
                EvenNumber = betResult.Even,
                OddNumber = betResult.Odd,
                FirstHalf = betResult.FirstHalf,
                SecondHalf = betResult.SecondHalf,
                FirstTwelve = betResult.FirstTwelve,
                SecondTwelve = betResult.SecondTwelve,
                ThirdTwelve = betResult.ThirdTwelve,
                FirstTwoToOne = betResult.FirstTwotoOne,
                SecondTwoToOne = betResult.SecondTwotoOne,
                ThirdTwoToOne = betResult.ThirdTwotoOne,
                Number = randomNumber
            });

            await _mediator.Send(new CreateCloseBetCommand { PlacebetId = openBet.id });

            return JsonSerializer.Serialize(betResult);
        }

        public async Task<string> Payout()
        {
            var payouts = new List<BetPayoutDetailsViewModel>();

            var latestBetResult = await _mediator.Send(new GetBetResultQuery());

            var customerBetResults = await _mediator.Send(new GetCustomerBetQuery());

            var groups = customerBetResults.Where(x => x.Placebet_Id == latestBetResult.Placebet_Id).GroupBy(x => x.Customer_Id);

            foreach (var singleGroup in groups)
            {
                var customerIdentityNumber = string.Empty;
                var betBreakdown = new List<BetDetailsViewModel>();
                var totalPayout = 0;

                foreach (var single in singleGroup)
                {
                    var singleBetBreakdown = new BetDetailsViewModel() { BetAmount = single.BetAmount };
                    customerIdentityNumber = single.Customer_Id;

                    var results = single.GetValue(latestBetResult, totalPayout);

                    singleBetBreakdown.BetType = results.BetType;
                    singleBetBreakdown.TotalWinning = results.winnings;
                    totalPayout = results.totalPayout;

                    if (singleBetBreakdown.BetType != "not a winning gamble")
                        betBreakdown.Add(singleBetBreakdown);
                }

                payouts.Add(new BetPayoutDetailsViewModel { CustomerIdentityNumber = customerIdentityNumber, TotalPayout = totalPayout, ListBetDetails = betBreakdown });
            }

            await _mediator.Send(new UpdatePayoutStatusCommand { PlacebetId = latestBetResult.Placebet_Id });

            return JsonSerializer.Serialize(payouts);
        }
    }
}
