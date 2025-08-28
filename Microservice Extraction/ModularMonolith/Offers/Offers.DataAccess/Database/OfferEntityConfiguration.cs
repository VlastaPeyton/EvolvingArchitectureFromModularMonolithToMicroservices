using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Offers.DataAccess.Database
{
    internal sealed class OfferEntityConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offers");
            builder.HasKey(offer => offer.Id);
            builder.Property(offer => offer.PreparedAt).IsRequired();
            builder.Property(offer => offer.OfferedFromDate).IsRequired();
            builder.Property(offer => offer.OfferedFromTo).IsRequired();
            builder.Property(offer => offer.Discount).IsRequired();
            builder.Property(offer => offer.CustomerId).IsRequired();
        }
    }
}
