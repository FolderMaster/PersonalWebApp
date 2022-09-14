using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Profiles
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}