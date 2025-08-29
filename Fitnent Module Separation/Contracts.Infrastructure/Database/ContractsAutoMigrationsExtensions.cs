using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database
{
    internal static class ContractsAutoMigrationsExtensions
    {
        public static IApplicationBuilder UseAutoContractsMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ContractsDbContext>();
            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
