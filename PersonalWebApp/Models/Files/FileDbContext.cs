using Microsoft.EntityFrameworkCore;
using PersonalWebApp.Models.Profiles;

namespace PersonalWebApp.Models.Files
{
    public class FileDbContext: DbContext
    {
        public DbSet<File> Files { get; set; }

        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}