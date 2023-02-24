using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class LegalEntityAddressEntityTypeConfiguration : IEntityTypeConfiguration<LegalEntityAddress>
    {
        public void Configure(EntityTypeBuilder<LegalEntityAddress> builder)
        {
            builder.ToTable("LegalEntityAddresses");

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.LegalEntityAddresses)
                .HasForeignKey(x => x.LegalEntityId);
        }
    }
}
