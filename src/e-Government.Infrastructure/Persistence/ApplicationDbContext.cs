﻿using e_Government.Application.Abstractions;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace e_Government.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}