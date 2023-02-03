using Microsoft.AspNetCore.Builder;

namespace RouletteAPI.ExceptionHandlerMiddleware
{
    public static class MiddleWare
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FailureResponeHandler>();
        }
    }
}
