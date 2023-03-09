using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class DocumentIEntityTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
