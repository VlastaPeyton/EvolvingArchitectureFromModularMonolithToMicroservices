using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Contracts.Data.Database
{
    // Apply EF Core migrations on app start up kako ne bih morao rucno da ih radim
    internal static class ContractsAutoMigrationExtensions
    {
        internal static IApplicationBuilder UseAutoContractsMigrations(this IApplicationBuilder applicationBuilder)
        {   
            using var scope = applicationBuilder.ApplicationServices.CreateScope(); // ApplicationServices je Root DI container, a mor Scope jer DbContext je AddScoped, ali posto je ovo app start up, nema HTTP request da naprave scope, pa CreateScope moram rucno
            var dbContext = scope.ServiceProvider.GetRequiredService<ContractsDbContext>();
            dbContext.Database.Migrate(); // Apply pending migrations

            return applicationBuilder; // => U Program.cs moze app.UseAutoMigrations().UseNesto1().UseNesto2()...
        }
    }
}
