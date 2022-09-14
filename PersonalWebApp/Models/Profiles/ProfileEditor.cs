using Microsoft.EntityFrameworkCore;

using PersonalWebApp.Models.Users;
using PersonalWebApp.Models.Files;

namespace PersonalWebApp.Models.Profiles
{
    public class ProfileEditor
    {
        public string Nick { get; set; }

        public string? Description { get; set; }

        public IFormFile? Avatar { get; set; }

        public ProfileEditor()
        {
        }

        public static async Task Edit(User u, ProfileEditor editor, IWebHostEnvironment
            webHostEnvironment, FileDbContext fileContext, ProfileDbContext profileContext)
        {
            profileContext.Profiles.Add(new Profile(u, editor, webHostEnvironment, fileContext));
            await profileContext.SaveChangesAsync();
        }
    }
}
