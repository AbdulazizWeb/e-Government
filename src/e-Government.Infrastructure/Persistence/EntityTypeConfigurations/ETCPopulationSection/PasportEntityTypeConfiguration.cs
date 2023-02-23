﻿using e_Government.Domain.Entities.PopulationSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCPopulationSection
{
    public class PasportEntityTypeConfiguration : IEntityTypeConfiguration<Pasport>
    {
        public void Configure(EntityTypeBuilder<Pasport> builder)
        {
            builder.HasKey(x => x.SerialNumber);
            //or    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            builder.HasIndex(x => x.SerialNumber).IsUnique();

            builder.HasOne(x => x.Population)
                .WithMany(x => x.Pasports)
                .HasForeignKey(x => x.PopulationId);            
        }
    }
}
