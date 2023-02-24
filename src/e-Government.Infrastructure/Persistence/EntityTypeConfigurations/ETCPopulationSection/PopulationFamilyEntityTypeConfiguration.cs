using e_Government.Domain.Entities.PopulationSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCPopulationSection
{
    public class PopulationPopulationEntityTypeConfiguration : IEntityTypeConfiguration<PopulationFamily>
    {
        public void Configure(EntityTypeBuilder<PopulationFamily> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Population)
                .WithMany(x => x.PopuletionPopulations)
                .HasForeignKey(x => x.Population1Id);
        }
    }
}
