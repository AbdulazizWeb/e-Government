using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class CertificateEntityTypeConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificates");

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.Certificates)
                .HasForeignKey(x => x.LegalEntityId);
        }
    }
}
