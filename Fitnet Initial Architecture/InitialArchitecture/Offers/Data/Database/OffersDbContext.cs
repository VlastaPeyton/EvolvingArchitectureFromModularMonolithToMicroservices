using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Offers.Data.Database
{   
    // Objasnjeno u Contracts
    internal sealed class OffersDbContext : DbContext
    {
        public OffersDbContext(DbContextOptions<OffersDbContext> options) : base(options) { }

        private const string Schema = "Offers";

        public DbSet<Offer> Offers {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new OfferEntityConfiguration());
        }
    }
}
