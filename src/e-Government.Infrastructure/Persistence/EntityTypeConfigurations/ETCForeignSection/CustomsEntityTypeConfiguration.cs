using e_Government.Domain.Entities.ForeignSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCForeignSection
{
    public class CustomsEntityTypeConfiguration : IEntityTypeConfiguration<Customs>
    {
        public void Configure(EntityTypeBuilder<Customs> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
