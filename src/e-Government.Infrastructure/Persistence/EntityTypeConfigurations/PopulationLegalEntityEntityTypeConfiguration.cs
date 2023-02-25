using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PopulationLegalEntityEntityTypeConfiguration : IEntityTypeConfiguration<PopulationLegalEntity>
    {
        public void Configure(EntityTypeBuilder<PopulationLegalEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Population)
                .WithMany(x => x.PopulationLegalEntities)
                .HasForeignKey(x => x.PopulationId);

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.LegalEntityPopulation)
                .HasForeignKey(x => x.LegalEntityId);
        }
    }
}
