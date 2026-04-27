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
    }
}
