using e_Government.Domain.Entities.PopulationSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCPopulationSection
{
    public class PopulationEntityTypeConfiguration : IEntityTypeConfiguration<Population>
    {
        public void Configure(EntityTypeBuilder<Population> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
