using HomeEstate.Domains.Entities.Apartment;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.DataAccess.Context
{
    public class ApartmentContext : DbContext
    {
        public DbSet<ApartmentData> Apartments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DbSession.ConnectionStrings);
        }
    }
}
