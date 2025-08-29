using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialArchitecture.Offers.Data.Database
{
    // Objasnjeno u Contracts
    internal class OfferEntityConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offers");
            builder.HasKey(offers => offers.Id);
            builder.Property(offers => offers.CustomerId).IsRequired();
            builder.Property(offers => offers.PreparedAt).IsRequired();
            builder.Property(offers => offers.Discount).IsRequired();
            builder.Property(offers => offers.OfferedFromDate).IsRequired();
            builder.Property(offers => offers.OfferedFromtTo).IsRequired();
        }
    }
}
