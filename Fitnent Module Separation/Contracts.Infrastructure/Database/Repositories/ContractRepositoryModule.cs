using Contracts.Domain;

namespace Contracts.Infrastructure.Database.Repositories
{
    internal static class ContractRepositoryModule
    {
        public static IServiceCollection AddContractsRepositories(this IServiceCollection services)
        {   
            // Repository je uvek AddScoped
            services.AddScoped<IContractsRepository, ContractsRepository>();
            return services;
        }
    }
}
