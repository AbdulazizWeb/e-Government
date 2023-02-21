using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class NotCitizenEntityTypeConfiguration : IEntityTypeConfiguration<NotCitizen>
    {
        public void Configure(EntityTypeBuilder<NotCitizen> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
