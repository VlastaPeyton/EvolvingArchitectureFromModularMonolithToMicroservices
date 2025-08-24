using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Offers.DataAccess.Database
{
    internal static class AutomaticMigrationsExtensions
    {
        internal static IApplicationBuilder UseAutomaticMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<OffersDbContext>();
            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
