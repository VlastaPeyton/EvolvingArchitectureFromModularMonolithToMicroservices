 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialArchitecture.Contracts.Data.Database
{   
    // Konfiguracija Contracts tabele umesto u ApplicationDbContext (tj umesto u ContractPersistance) u OnModelCreating 
    internal sealed class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
    {   
        // Mora ova metoda zbog interface
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts"); // <= Microsoft.EntityFrameworkCore.Relational mora da se instalira 
            builder.HasKey(contract => contract.Id);
            builder.Property(contract => contract.PreparedAt).IsRequired();
            builder.Property(contract => contract.Duration).IsRequired();
            builder.Property(contract => contract.ExpiringAt).IsRequired();
            // Nisam za ostale kolone pravio uslove. 
        }
    }
}
