using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Offers.DataAccess.Database
{
    public sealed class OffersDbContext : DbContext
    {
        private const string Schema = "Offers";
        public DbSet<Offer> Offers;

        public OffersDbContext(DbContextOptions<OffersDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new OfferEntityConfiguration());
        }
    }
}
