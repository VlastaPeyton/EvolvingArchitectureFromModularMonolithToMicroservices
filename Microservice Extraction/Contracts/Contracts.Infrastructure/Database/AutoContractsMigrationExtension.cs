

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Infrastructure.Database
{
    internal static class AutoContractsMigrationExtension
    {
        public static IApplicationBuilder UseAutoContractsMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<ContractsDbContext>();
            context.Database.Migrate();

            return app;
        }
    }
}
