using MediatR;
using Microsoft.AspNetCore.Http;
using RoulettePlatform.Data.Queries;
using System.Threading.Tasks;
using System;

namespace RouletteAPI.ExceptionHandlerMiddleware
{
    public class FailureResponeHandler
    {
        private readonly RequestDelegate _next;
        private IMediator _mediator;

        public FailureResponeHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            _mediator = mediator;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex);
            }
        }

        private async Task HandleExceptionAsync(Exception exception)
        {
            
            await _mediator.Send(new CreateExceptionCommand { StackTrace = exception.StackTrace, ErrorMessage = exception.Message });
        }
    }
}
