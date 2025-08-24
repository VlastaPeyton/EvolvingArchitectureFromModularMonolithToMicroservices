using Contracts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contracts.Infrastructure.Database
{
    internal sealed class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
    {   // Mora metoda zbog interface
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");
            builder.HasKey(contract => contract.Id);
            builder.Property(contract => contract.PreparedAt).IsRequired();
            builder.Property(contract => contract.Duration).IsRequired();
            builder.Property(contract => contract.ExpiringAt).IsRequired();
            // Nisam za ostale kolone pravio uslove.

        }
    }
}
