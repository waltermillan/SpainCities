using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public partial class SpainCitiesCotext : DbContext
    {
        public SpainCitiesCotext()
        {
        }

        public SpainCitiesCotext(DbContextOptions<SpainCitiesCotext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);  // Define CityId as the primary key
            modelBuilder.Entity<Province>()
                .HasKey(c => c.Id);  // Define IdProvince as the primary key
            modelBuilder.Entity<Region>()
                .HasKey(c => c.Id);  // Define IdRegion as the primary key
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-EC6OIR8\\SQLEXPRESS;Initial Catalog=SpainCitiesDb;Trusted_Connection=True;TrustServerCertificate=True");

    }
}
