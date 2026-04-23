using HomeEstate.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.DataAccess.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DbSession.ConnectionStrings);
        }
    }
}
