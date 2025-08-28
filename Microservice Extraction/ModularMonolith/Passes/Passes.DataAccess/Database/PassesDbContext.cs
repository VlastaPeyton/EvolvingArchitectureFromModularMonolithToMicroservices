using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Passes.DataAccess.Database
{
    public sealed class PassesDbContext : DbContext
    {
        private const string Schema = "Passes";

        public DbSet<Pass> Passes => Set<Pass>();
        public PassesDbContext(DbContextOptions<PassesDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new PassEntityConfiguration());
            // Inbox-Outbox pattern. Zbog AutoPassesMigrationExtension automatski se naprave ove 3 tabele u bazi ali za Schema="Passes" jer ovo nemam u Reports i Offers
            modelBuilder.AddInboxStateEntity(); // InboxState tabela u bazi prati poruke(event in RabbitMQ) su već primljene i obrađene iz RabbitMQ
            modelBuilder.AddOutboxMessageEntity(); // OutboxMessage tabela u bazi u koju servis stavi event pre nego sto ga MassTrasitom posalje na RabbitMQ
            modelBuilder.AddOutboxStateEntity(); // OutboxState tabela u bazi koja registruje stanje slanja poruka(event) npr. status (da li je poruka uspešno poslata, u kom pokušaju, itd).
        }
    }
}
