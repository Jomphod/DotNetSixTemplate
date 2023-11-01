using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Configurations
{
    public class SystemQueryConfiguration : IEntityTypeConfiguration<SystemQuery>
    {
        public void Configure(EntityTypeBuilder<SystemQuery> builder)
        {

            builder
                .HasKey(a => a.query_name);

            builder
                .ToTable("SystemQuery");
        }
    }
}
