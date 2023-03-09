using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Foreigner> Foreigners { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<LegalEntityAddress> LegalAddresses { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Population> Populations { get; set; }
        public DbSet<PopulationAddress> PopulationAddresses { get; set; }
        public DbSet<PopulationFamily> PopulationFamilies { get; set; }
        public DbSet<Visa> Visas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}