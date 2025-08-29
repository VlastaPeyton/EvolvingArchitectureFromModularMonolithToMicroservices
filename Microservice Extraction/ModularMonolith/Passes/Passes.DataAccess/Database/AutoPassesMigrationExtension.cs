
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Passes.DataAccess.Database
{
    internal static class AutoPassesMigrationExtension
    {
        public static IApplicationBuilder UseAutoPassesMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PassesDbContext>();
            context.Database.Migrate();

            return applicationBuilder;

        }
    }
}
