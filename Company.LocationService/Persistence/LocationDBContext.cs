using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Company.LocationService.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Company.LocationService.Persistence 
{
    public class LocationDbContext : DbContext 
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
        public DbSet<LocationRecord> LocationRecords { get; set; }
    }

    public class LocationDbContextFactory : IDesignTimeDbContextFactory<LocationDbContext>
    {
        public LocationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocationDbContext>();
            // var connectionString = Startup.Configuration.GetSection("postgres:cstr").Value;
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=locationservice;Username=john;Password=doe;");
            return new LocationDbContext(optionsBuilder.Options);
        }
    }
    
}