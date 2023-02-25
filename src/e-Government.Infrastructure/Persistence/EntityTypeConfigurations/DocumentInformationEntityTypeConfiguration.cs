using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class DocumentInformationEntityTypeConfiguration : IEntityTypeConfiguration<DocumentInformation>
    {
        public void Configure(EntityTypeBuilder<DocumentInformation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.IssuedByBranchLegalEntity)
                .WithMany(x => x.DocumentInformations)
                .HasForeignKey(x => x.IssuedByBranchLegalEntityId);
        }
    }
}
