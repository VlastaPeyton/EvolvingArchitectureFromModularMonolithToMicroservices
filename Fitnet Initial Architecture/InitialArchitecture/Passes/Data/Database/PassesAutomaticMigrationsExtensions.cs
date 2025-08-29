namespace InitialArchitecture.Passes.Data.Database
{   
    // Objasnjeno u Contracts
    internal static class PassesAutomaticMigrationsExtensions
    {
        public static IApplicationBuilder UseAutomaticPassesMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PassesDbContext>();
            context.Database.EnsureCreated();

            return applicationBuilder;
        }
    }
}
