using e_Government.Domain.Entities.PopulationSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCPopulationSection
{
    public class PopulationPopulationEntityTypeConfiguration : IEntityTypeConfiguration<PopulationPopulation>
    {
        public void Configure(EntityTypeBuilder<PopulationPopulation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Population)
                .WithMany(x => x.PopuletionPopulations)
                .HasForeignKey(x => x.Population1Id);
        }
    }
}
