using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PopulationFamilyEntityTypeConfiguration : IEntityTypeConfiguration<PopulationFamily>
    {
        public void Configure(EntityTypeBuilder<PopulationFamily> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Population1)
                .WithMany(x => x.PopulationFamilies)
                .HasForeignKey(x => x.Population1Id);

            builder.HasOne(x => x.Population2)
                .WithMany(x => x.FamilyPopulation)
                .HasForeignKey(x => x.Population2Id);
        }
    }
}
