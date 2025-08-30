
using Contracts.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Infrastructure.Database.Repository
{
    internal static class RepositoryModule
    {
        public static IServiceCollection AddContractsRepository(this IServiceCollection services)
        {
            services.AddScoped<IContractRepository, IContractRepository>();
            services.AddScoped<IBindingContractRepository, BindingContractRepository>();
            return services;
        }
    }
}
