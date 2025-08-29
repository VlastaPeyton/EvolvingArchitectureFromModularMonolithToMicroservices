using InitialArchitecture.Offers.Data.Database;

namespace InitialArchitecture.Offers
{
    internal static class OffersModuleExtensions
    {
        public static IServiceCollection AddOffers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOffersDatabase(configuration);
            return services;
        }

        public static IApplicationBuilder UseOffers(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseOffersDatabase();
            return applicationBuilder;
        }
    }
}
