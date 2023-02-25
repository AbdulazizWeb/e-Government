using e_Government.Application.Abstractions;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<DocumentInformation> Documents { get; set; }
        public DbSet<Foreigner> Foreigners { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<LegalEntityAddress> LegalAddresses { get; set; }
        public DbSet<Pasport> Pasports { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Population> Populations { get; set; }
        public DbSet<PopulationAddress> populationAddresses { get; set; }
        public DbSet<PopulationFamily> PopulationFamilies { get; set; }
        public DbSet<Visa> Visas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}