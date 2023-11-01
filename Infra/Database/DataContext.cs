using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database
{
    public class DataContext : DbContext
    {
        public DataContext(IServiceProvider serverProvider, DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProvinceConfiguration());
            builder.ApplyConfiguration(new PointOfInterestConfiguration());
            builder.Entity<SystemQuery>().HasNoKey();
        }

        #region DbSet List
        public DbSet<Province> Provinces { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
        public DbSet<SystemQuery> SystemQuery { get; set; }
        #endregion
    }
}