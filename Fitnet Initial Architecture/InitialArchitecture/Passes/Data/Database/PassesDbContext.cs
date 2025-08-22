using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Passes.Data.Database
{   
    // Objasnjeno u Contracts
    internal sealed class PassesDbContext : DbContext
    {
        public PassesDbContext(DbContextOptions<PassesDbContext> options) : base(options) { }

        private const string Schema = "Passes";

        public DbSet<Pass> Passes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new PassEntityConfiguration());
        }
    }
}
