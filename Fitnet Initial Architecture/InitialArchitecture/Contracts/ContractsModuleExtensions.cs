using InitialArchitecture.Contracts.Data.Database;

namespace InitialArchitecture.Contracts
{    
    public static class ContractsModuleExtensions
    {   
        internal static IServiceCollection AddContracts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContractsDatabase(configuration); // AddDatabase je extension iz DatabaseModuleExtension.cs

            return services; // => u Program.cs mora builder.Services.AddContracts(builder.Configuration)
        }
        
        internal static IApplicationBuilder UseContracts(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseContractsDatabase(); // UseDatabase je extension iz DatabaseModuleExtensions.cs

            return applicationBuilder; // => u Program.cs mora app.UseContracts()
        }
    }
}
