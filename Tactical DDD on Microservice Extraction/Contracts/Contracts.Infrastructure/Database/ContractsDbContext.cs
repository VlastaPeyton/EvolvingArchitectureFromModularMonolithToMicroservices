using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database
{
    public sealed class ContractsDbContext : DbContext
    {
        private const string Schema = "Contracts";
        public DbSet<Contract> Contracts;
        public ContractsDbContext(DbContextOptions<ContractsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfiguration(new ContractEntityConfiguration());
        }
    }
}
