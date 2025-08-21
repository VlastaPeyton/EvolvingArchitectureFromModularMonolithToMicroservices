using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Contracts.Data.Database
{   
    // Contracts module has its own "ApplicationDbContext" 
    internal sealed class ContractsDbContext: DbContext
    {   
        public ContractsDbContext(DbContextOptions<ContractsDbContext> options) : base(options) { }
        
        private const string Schema = "Contracts";
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new ContractEntityConfiguration()); // U ContractEntityConfiguration definisali sve sto inace bih u OnModelCreating
        }
    }
}
