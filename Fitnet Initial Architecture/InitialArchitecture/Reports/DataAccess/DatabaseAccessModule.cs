namespace InitialArchitecture.Reports.DataAccess
{
    internal static class DatabaseAccessModule
    {
        public static IServiceCollection AddReportsDataAcces(this IServiceCollection services)
        {   /* Registrujem interface da bude prepoznatljiv kao klasa i to Singleton jer zelim da jedna istanca fabrike bude kroz ceo zivotni vek app posto tako treba za db connection
             tj neam potrebe da pravim novu fabriku za svaki HTTP Request jer fabrika ne zavisi od Request. Ovo je stateless i zato je Singleton.
               DbContext je Scoped jer se pravi za svaki HTTP Request posto je stateful.
            */
            services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

            return services;
        }
    }
}
