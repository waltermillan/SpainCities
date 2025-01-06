using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Data
{
    public partial class SpainCitiesContext(DbContextOptions<SpainCitiesContext> options, IConfiguration configuration) : DbContext(options)
    {
        private readonly IConfiguration _configuration = configuration;

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);  // Define Id (City) as the primary key
            modelBuilder.Entity<Province>()
                .HasKey(c => c.Id);  // Define Id (Province) as the primary key
            modelBuilder.Entity<Region>()
                .HasKey(c => c.Id);  // Define Id (Region) as the primary key
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lee el connection string desde el archivo appsettings.json
            var connectionString = _configuration.GetConnectionString("SpainCitiesConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
