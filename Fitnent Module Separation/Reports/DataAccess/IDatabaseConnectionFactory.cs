using System.Data;

namespace Reports.DataAccess
{   
    // Objasnjeno u InternalArchitecture
    internal interface IDatabaseConnectionFactory
    {
        IDbConnection Create();  // Metoda vraca instancu(Klasu) koja implementira IDbConnection 
    }
}
