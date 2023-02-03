using MediatR;
using RoulettePlatform.Data.Queries;
using RoulettePlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoulettePlatform.Classes
{
    public class History : IHistoryInterface
    {
        private readonly IMediator _mediator;

        public History(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<string> GetPreviousSpinResult()
        {
            var previousSpins = await _mediator.Send(new GetPreviousSpinsQuery());
            return JsonSerializer.Serialize(previousSpins);
        }
    }
}
