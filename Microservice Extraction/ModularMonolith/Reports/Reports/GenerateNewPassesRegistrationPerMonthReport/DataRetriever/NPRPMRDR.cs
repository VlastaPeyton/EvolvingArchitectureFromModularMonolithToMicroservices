

using System;
using Dapper;
using Reports.DataAccess;

namespace Reports.GenerateNewPassesRegistrationPerMonthReport.DataRetriever
{
    // Koristim Dapper, a ne EF Core, i zato IDatabaseConnectionFactory mi treba

    internal class NewPassesRegistrationPerMonthReportDataRetriever(IDatabaseConnectionFactory dbConnectionFactory, TimeProvider timeProvider) : INewPassesRegistrationPerMonthReportDataRetriever
    {
        public async Task<IReadOnlyCollection<NewPassesRegistrationsPerMonthDTO>> GetReportsDataAsync(CancellationToken cancellationToken)
        {
            using var connection = dbConnectionFactory.Create(); // Nakon zavrsetka metode, using ce automatski uraditi connection.Dispose() cime ce connection.Close() + izbaciti je iz pool. Ovim osiguravam da svaki put ce biti nova konekcija i prevent race conditions.

            var query = $@"
                SELECT EXTRACT(MONTH FROM ""Passes"".""From"")::INTEGER AS ""{nameof(NewPassesRegistrationsPerMonthDTO.MonthOrder)}"",
                       to_char(""Passes"".""From"", 'Month') AS ""{nameof(NewPassesRegistrationsPerMonthDTO.MonthName)}"",
                       COUNT(*) AS ""{nameof(NewPassesRegistrationsPerMonthDTO.RegisteredPasses)}"",
                
                FROM ""Passes"".""Passes"" 
                
                WHERE EXTRACT(YEAR FROM ""Passes"".""From"") = '{timeProvider.GetUtcNow().Year}'
                GROUP BY ""{nameof(NewPassesRegistrationsPerMonthDTO.MonthName)}"", ""{nameof(NewPassesRegistrationsPerMonthDTO.MonthOrder)}""
                ORDERY BY ""{nameof(NewPassesRegistrationsPerMonthDTO.MonthOrder)}""
            ";

            var queryDefinition = new CommandDefinition(query, cancellationToken); // <= Dapper NuGet
            var newPassesRegistrationsPerMonthDTOs = await connection.QueryAsync<NewPassesRegistrationsPerMonthDTO>(queryDefinition);
            // newPassesRegistrationsPerMonthDTOs je IEnumearble i povezano je sa konekcijom, pa ako konekcija slucajno pukne, ova varijabla postaje null i zato pretvorim to sve u listu rucno jer nema ToListAsync kao u EF Core

            return [.. newPassesRegistrationsPerMonthDTOs]; // Kao u TS da napravi lsitu od elemenata iz newPassesRegistrationsPerMonthDTOs
        }
    }
}
