using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Infrastructure.Database.Repository
{
    internal static class RepositoryModule
    {
        public static IServiceCollection AddContractsRepository(this IServiceCollection services)
        {
            services.AddScoped<IContractsRepository, IContractsRepository>();
            return services;
        }
    }
}
