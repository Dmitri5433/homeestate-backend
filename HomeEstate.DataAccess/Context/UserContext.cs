using HomeEstate.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.DataAccess.Context
{
    public class UserContext : DbContext
    {
        public UserContext() { }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserData> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }
    }
}
