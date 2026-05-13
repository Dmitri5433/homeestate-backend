using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Entities.City;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.DataAccess.Context
{
    public class ApartmentContext : DbContext
    {
        public ApartmentContext() { }
        public ApartmentContext(DbContextOptions<ApartmentContext> options) : base(options) { }

        public DbSet<ApartmentData> Apartments { get; set; }
        public DbSet<ApartmentImageData> ApartmentImages { get; set; }
        public DbSet<ApartmentDescriptionData> ApartmentDescriptions { get; set; }
        public DbSet<CityData> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentData>()
                .HasMany(a => a.Images)
                .WithOne(i => i.Apartment)
                .HasForeignKey(i => i.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApartmentData>()
                .HasOne(a => a.Description)
                .WithOne(d => d.Apartment)
                .HasForeignKey<ApartmentDescriptionData>(d => d.ApartmentId)
                .IsRequired(false);

            modelBuilder.Entity<ApartmentData>()
                .HasOne(a => a.City)
                .WithMany(c => c.Apartments)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
