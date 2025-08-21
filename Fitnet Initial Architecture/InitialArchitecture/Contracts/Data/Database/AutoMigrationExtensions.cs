using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Contracts.Data.Database
{
    // Apply EF Core migrations on app start up kako ne bih morao rucno da ih radim
    internal static class AutoMigrationExtensions
    {
        internal static IApplicationBuilder UseAutoMigrations(this IApplicationBuilder applicationBuilder)
        {   
            using var scope = applicationBuilder.ApplicationServices.CreateScope(); // Root DI container
            var dbContext = scope.ServiceProvider.GetRequiredService<ContractsDbContext>();
            dbContext.Database.Migrate(); // Apply pending migrations

            return applicationBuilder; // => U Program.cs moze app.UseAutoMigrations().UseNesto1().UseNesto2()...
        }
    }
}
