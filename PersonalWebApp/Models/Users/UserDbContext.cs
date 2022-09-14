using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Users
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}