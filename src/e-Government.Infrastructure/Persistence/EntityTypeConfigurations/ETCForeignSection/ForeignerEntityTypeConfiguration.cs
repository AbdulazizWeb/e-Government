using e_Government.Domain.Entities.ForeignSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCForeignSection
{
    public class ForeignerEntityTypeConfiguration : IEntityTypeConfiguration<Foreigner>
    {
        public void Configure(EntityTypeBuilder<Foreigner> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
