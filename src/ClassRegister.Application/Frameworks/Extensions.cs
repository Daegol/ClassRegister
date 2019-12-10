using Microsoft.AspNetCore.Builder;

namespace ClassRegister.Application.Frameworks
{
    public static class Extensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ErrorHandlerMiddleware));
    }
}