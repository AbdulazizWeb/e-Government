using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PasportEntityTypeConfiguration : IEntityTypeConfiguration<Pasport>
    {
        public void Configure(EntityTypeBuilder<Pasport> builder)
        {
            builder.ToTable("Pasports");

            builder.HasIndex(x => x.SerialNumber).IsUnique();

            builder.HasOne(x => x.Population)
                .WithMany(x => x.Pasports)
                .HasForeignKey(x => x.PopulationId);
        }
    }
}
