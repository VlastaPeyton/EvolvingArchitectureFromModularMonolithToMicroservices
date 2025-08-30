
using Microsoft.AspNetCore.Builder;

namespace Common.API.ErrorHandling
{
    public static class ErrorHandlingExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>(); // ExceptionMiddleware se automatski poziva jer sam ga registrovao 
            return app;
        }
    }
}
