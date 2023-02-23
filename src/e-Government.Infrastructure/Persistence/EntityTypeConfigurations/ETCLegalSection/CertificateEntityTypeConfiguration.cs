using e_Government.Domain.Entities.Legal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCLegalSection
{
    public class CertificateEntityTypeConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(x => x.SerialNumber);

            builder.HasIndex(x => x.SerialNumber);

            builder.HasOne(x => x.IssuedByBranch)
                .WithMany(x => x.Certificates)
                .HasForeignKey(x => x.IssuedByBranchId);

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.Certificates)
                .HasForeignKey(x => x.LegalEntityId);

        }
    }
}
