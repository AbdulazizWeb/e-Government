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
    public class ForeignerEntityTypeConfiguration : IEntityTypeConfiguration<Foreigner>
    {
        public void Configure(EntityTypeBuilder<Foreigner> builder)
        {
            builder.HasKey(e => e.Id);           
        }
    }
}
