using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Passes.DataAccess.Database
{
    internal class PassEntityConfiguration : IEntityTypeConfiguration<Pass>
    {
        public void Configure(EntityTypeBuilder<Pass> builder)
        {
            builder.ToTable("Passes");
            builder.HasKey(pass => pass.Id);
            builder.Property(pass => pass.CustomerId).IsRequired();
            builder.Property(pass => pass.To).IsRequired();
        }
    }
}
