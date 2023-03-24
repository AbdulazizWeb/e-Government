using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PasportEntityTypeConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable("Pasports");

            builder.HasOne(x => x.Population)
                .WithMany(x => x.Pasports)
                .HasForeignKey(x => x.PopulationId);
        }
    }
}
