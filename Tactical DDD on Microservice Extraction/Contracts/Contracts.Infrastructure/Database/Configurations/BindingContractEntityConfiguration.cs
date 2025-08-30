using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain;
using Contracts.Domain.CustomId;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contracts.Infrastructure.Database.Configurations
{
    internal sealed class BindingContractEntityConfiguration : IEntityTypeConfiguration<BindingContract>
    {
        public void Configure(EntityTypeBuilder<BindingContract> builder)
        {
            builder.ToTable("BindingContracts");

            // Znam iz EShopMicroservices.
            builder.HasKey(contract => contract.Id);
            builder.Property(contract => contract.Id)
                   .HasConversion(id => id.Value,
                                  value => new BindingContractId(value))
                   .ValueGeneratedOnAdd();

            // Svako custom type polje moram ovako. Znam iz EShopMicroservices.
            builder.Property(contract => contract.ContractId)
                   .HasConversion(id => id.Value,
                                  value => new ContractId(value));

            builder.Property(contract => contract.ContractId).IsRequired();
            builder.Property(contract => contract.CustomerId).IsRequired();
            builder.Property(contract => contract.Duration).IsRequired();
            builder.Property(contract => contract.TerminatedAt);
            builder.Property(contract => contract.BindingFrom).IsRequired();
            builder.Property(contract => contract.ExpiringAt).IsRequired();

            builder.HasMany(bContract => bContract.AttachedAnnexes)
                   .WithOne()
                   .HasForeignKey(annex => annex.BindingContractId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
