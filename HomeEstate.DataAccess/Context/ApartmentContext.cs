using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Entities.City;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.DataAccess.Context
{
    public class ApartmentContext : DbContext
    {
        public DbSet<ApartmentData> Apartments { get; set; }
        public DbSet<ApartmentImageData> ApartmentImages { get; set; }
        public DbSet<ApartmentDescriptionData> ApartmentDescriptions { get; set; }
        public DbSet<CityData> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ── 1:N — Apartment -> Images ───────────────────────────
            // Одна квартира имеет МНОГО изображений
            // При удалении квартиры — все изображения удаляются (Cascade)
            modelBuilder.Entity<ApartmentData>()
                .HasMany(a => a.Images)
                .WithOne(i => i.Apartment)
                .HasForeignKey(i => i.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ── 1:1 — Apartment -> Description ─────────────────────
            // У квартиры одно описание (необязательно)
            // Description — зависимая сторона (содержит FK)
            modelBuilder.Entity<ApartmentData>()
                .HasOne(a => a.Description)
                .WithOne(d => d.Apartment)
                .HasForeignKey<ApartmentDescriptionData>(d => d.ApartmentId)
                .IsRequired(false);

            // ── N:1 — Apartment -> City ─────────────────────────────
            // Много квартир принадлежат одному городу
            // Restrict — нельзя удалить город если есть квартиры
            modelBuilder.Entity<ApartmentData>()
                .HasOne(a => a.City)
                .WithMany(c => c.Apartments)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
