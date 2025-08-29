namespace Reports.DataAccess
{
    internal static class DatabaseAccessModule
    {
        internal static IServiceCollection AddReportsDataAccess(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
            return services;
        }
    }
}
