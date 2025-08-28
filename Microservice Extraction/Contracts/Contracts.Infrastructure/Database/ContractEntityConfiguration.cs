

using Contracts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contracts.Infrastructure.Database
{
    internal sealed class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");
            builder.HasKey(contract => contract.Id);
            builder.Property(contract => contract.PreparedAt).IsRequired();
            builder.Property(contract => contract.SignedAt).IsRequired();
            // Ostale kolone necu da postavljam zahteve

        }
    }
}
