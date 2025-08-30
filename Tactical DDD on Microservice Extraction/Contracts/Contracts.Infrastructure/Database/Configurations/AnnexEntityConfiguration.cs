

using Contracts.Domain;
using Contracts.Domain.CustomId;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contracts.Infrastructure.Database.Configurations
{
    internal sealed class AnnexEntityConfiguration : IEntityTypeConfiguration<Annex>
    {
        public void Configure(EntityTypeBuilder<Annex> builder)
        {
            builder.ToTable("Annexes");
            
            builder.HasKey(annex => annex.Id);
            builder.Property(annex => annex.Id) // Znam iz EShopMicroservices
                   .HasConversion(id => id.Value,
                                  value => new AnnexId(value))
                   .ValueGeneratedOnAdd();

            builder.Property(annex => annex.BindingContractId)
                   .HasConversion(id => id.Value,
                                  value => new BindingContractId(value))
                   .IsRequired();

            builder.Property(a => a.ValidFrom).IsRequired();

            builder.HasOne<BindingContract>()
                   .WithMany(bContract => bContract.AttachedAnnexes)
                   .HasForeignKey(annex => annex.BindingContractId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
