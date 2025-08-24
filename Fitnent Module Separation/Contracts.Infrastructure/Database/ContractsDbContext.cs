using Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database
{
    public class ContractsDbContext : DbContext
    {
        private const string Schema = "Contracts";
        public DbSet<Contract> Contracts;
        public ContractsDbContext(DbContextOptions<ContractsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new ContractEntityConfiguration());
        }
    }
}
