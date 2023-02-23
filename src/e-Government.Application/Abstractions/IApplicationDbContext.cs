﻿using e_Government.Domain.Entities;
using e_Government.Domain.Entities.ForeignSection;
using e_Government.Domain.Entities.Legal;
using e_Government.Domain.Entities.PopulationSection;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<Customs> CustomOffices { get; set; }
        public DbSet<Foreigner> Foreigners { get; set; }
        public DbSet<Visa> Visas { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<IssuedByBranch> IssuedByBranchs { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<Pasport> Pasports { get; set; }
        public DbSet<Population> Populations { get; set; }
        public DbSet<PopulationPopulation> PopulationPopulations { get; set; }
        public DbSet<Address> Address { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}