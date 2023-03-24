using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class VisaEntityTypeConfiguration : IEntityTypeConfiguration<Visa>
    {
        public void Configure(EntityTypeBuilder<Visa> builder)
        {
            builder.ToTable("Visas");

            builder.HasOne(x => x.Foreigner)
                .WithMany(x => x.Visas)
                .HasForeignKey(x => x.ForeignerId);
        }
    }
}
