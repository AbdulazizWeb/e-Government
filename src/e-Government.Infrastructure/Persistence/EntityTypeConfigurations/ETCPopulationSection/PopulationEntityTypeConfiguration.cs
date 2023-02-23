using e_Government.Domain.Entities.PopulationSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Infrastructure.Persistence.EntityTypeConfigurations.ETCPopulationSection
{
    public class PopulationEntityTypeConfiguration : IEntityTypeConfiguration<Population>
    {
        public void Configure(EntityTypeBuilder<Population> builder)
        {
            builder.HasKey(x => x.Id);           
        }
    }
}
