using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PopulationAddressEntityTypeConfiguration : IEntityTypeConfiguration<PopulationAddress>
    {
        public void Configure(EntityTypeBuilder<PopulationAddress> builder)
        {
            builder.ToTable("PopulationAddresses");

            builder.HasOne(x => x.Population)
                .WithMany(x => x.PopulationAddresses)
                .HasForeignKey(x => x.PopulationId);
        }
    }
}
