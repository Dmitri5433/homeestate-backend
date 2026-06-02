using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeEstate.Domains;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Entities.City;
using HomeEstate.Domains.Entities.User;

namespace HomeEstate.DataAccess.Context
{
    public class DbSession : IdentityDbContext<User>
    {
        public DbSession(DbContextOptions<DbSession> options) : base(options)
        {
        }

        public static string ConnectionStrings { get; set; } = string.Empty;

        public DbSet<ApartmentData> Apartments { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<CityData> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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