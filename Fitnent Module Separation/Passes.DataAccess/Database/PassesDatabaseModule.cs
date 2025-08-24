using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Passes.DataAccess.Database
{
    internal static class DatabaseModule
    {
        private const string ConnectionStringConfigurationSection = "Modules:Passes:ConnectionStrings:Primary";

        internal static IServiceCollection AddPassesDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetRequiredSection(ConnectionStringConfigurationSection).Value;
            services.AddDbContext<PassesDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        internal static IApplicationBuilder UsePassesDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutoPassesMigrations();

            return applicationBuilder;
        }
    }
}
