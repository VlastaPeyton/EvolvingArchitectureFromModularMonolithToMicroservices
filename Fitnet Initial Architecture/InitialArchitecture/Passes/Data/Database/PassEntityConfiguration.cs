using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialArchitecture.Passes.Data.Database
{   
    // Objasnjeno u Contracts
    internal sealed class PassEntityConfiguration : IEntityTypeConfiguration<Pass>
    {
        public void Configure(EntityTypeBuilder<Pass> builder)
        {
            builder.ToTable("Passes");
            builder.HasKey(passes => passes.Id);
            builder.Property(passes => passes.CustomerId).IsRequired();
            builder.Property(passes => passes.From).IsRequired();
            builder.Property(passes => passes.To).IsRequired(); 
        }
    }
}
