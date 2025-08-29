using System.Data;

namespace InitialArchitecture.Reports.DataAccess
{   
    // Ovo u Offers, Contracts i Passes nisam radio, jer sam tamo koristio EF Core koji sam automatski otvara i zatvara konekciju, dok cu ovde koristiti Dapper umesto EF Core, pa moram rucno odrzavati konekciju
    internal interface IDatabaseConnectionFactory
    {
        IDbConnection Create();  // Metoda vraca instancu(Klasu) koja implementira IDbConnection 
    }
}
