using System.Security.Cryptography.Xml;
using Contracts.Domain;
using Contracts.Domain.CustomId;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contracts.Infrastructure.Database.Configurations
{
    internal sealed class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");

            builder.HasKey(contract => contract.Id);
            // Id polje je tipa custom i zato mora ovo. Znam iz EShopMicroservices.
            builder.Property(contract => contract.Id)
                   .HasConversion(id => id.Value, // Db Write
                                   value => new ContractId(value)) // Db Read
                   .ValueGeneratedOnAdd();  // Baza dodaje novu vrednost za svaku novu vrstu jer je ovo Id polje.
            
            builder.Property(contract => contract.PreparedAt).IsRequired();

            builder.OwnsOne(contract => contract.Signature, owned =>
            {   // owned.ToTable("Signatures"); - napravio bi sva Signature polja u posebnoj tabeli. Ovako ce biti u Contracts tabeli.
                owned.Property(signature => signature.Date).IsRequired();
                owned.Property(signature => signature.Value).IsRequired().HasMaxLength(100);
            });

        }
    }
}
