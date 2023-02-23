using e_Government.Domain.Entities.ForeignSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCForeignSection
{
    public class VisaEntityTypeConfiguration : IEntityTypeConfiguration<Visa>
    {
        public void Configure(EntityTypeBuilder<Visa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Number).IsUnique();

            builder.HasOne(x => x.Foreigner)
                .WithMany(x => x.Visas)
                .HasForeignKey(x => x.ForeignerId);

            builder.HasOne(x => x.Customs)
                .WithMany(x => x.Visas)
                .HasForeignKey(x => x.CustomsId);
        }
    }
}
