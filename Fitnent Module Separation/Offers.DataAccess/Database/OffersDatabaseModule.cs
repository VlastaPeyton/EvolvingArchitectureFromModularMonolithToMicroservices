using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Offers.DataAccess.Database
{
    internal static class DatabaseModule
    {
        private const string ConnectionStringConfigurationSection = "Modules:Offers:ConnectionStrings:Primary";

        internal static IServiceCollection AddOffersDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection(ConnectionStringConfigurationSection).Value;
            services.AddDbContext<OffersDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        internal static IApplicationBuilder UseOffersDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutomaticMigrations();

            return applicationBuilder;
        }
    }
}
