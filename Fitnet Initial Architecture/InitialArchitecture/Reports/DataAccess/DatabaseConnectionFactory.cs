using System.Data;
using Npgsql;

namespace InitialArchitecture.Reports.DataAccess
{
    internal sealed class DatabaseConnectionFactory(IConfiguration configuration) : IDatabaseConnectionFactory
    {   
        // Fabrika nece da sadrzi nijedan connection koji napravi jer to nije dobra praksa, obizorm da korisitm "using" kad pravim konekciju.
        public IDbConnection Create()
        {   
            var connection = new NpgsqlConnection(configuration.GetConnectionString("Reports"));
            // NpgSql sadrzi pool sa svim non-active closed connections, ali u klasi gde pozivam ovu metodu, nakon "using" aktivna konecija se Dispose automatski (Close + izbaci iz pool). Kada se app ugasi, automatski se pool prazni.
            connection.Open(); 

            return connection;
        }
        
    }
}
