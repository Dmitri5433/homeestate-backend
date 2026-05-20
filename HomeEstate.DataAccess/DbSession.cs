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
        }
    }
}