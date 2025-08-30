
using Contracts.Domain;
using Contracts.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database
{
    public sealed class ContractsDbContext : DbContext
    {
        private const string Schema = "Contracts";
        public DbSet<Contract> Contracts;
        public DbSet<BindingContract> BindingContracts;
        public ContractsDbContext(DbContextOptions<ContractsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new ContractEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BindingContractEntityConfiguration());
        }
    }
}
