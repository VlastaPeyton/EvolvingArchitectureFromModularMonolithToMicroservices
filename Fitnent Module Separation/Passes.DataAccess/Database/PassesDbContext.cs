using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Passes.DataAccess.Database
{
    public class PassesDbContext : DbContext
    {
        private const string Schema = "Passes";
        public DbSet<Pass> Passes;

        public PassesDbContext(DbContextOptions<PassesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new PassEntityConfiguration());

        }

    }
}
