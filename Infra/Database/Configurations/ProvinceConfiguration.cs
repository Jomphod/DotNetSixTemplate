using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder){

            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            builder
                .Property(m => m.Description)
                .HasMaxLength(225);
            
            builder
                .ToTable("Provinces");
        }
    }
}