using System.Drawing;

using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Models.Profiles
{
    public class ProfileEditor
    {
        public string Nick { get; set; }

        public string? Description { get; set; }

        public byte[]? Avatar { get; set; }

        public ProfileEditor()
        {
        }

        public static async Task Edit(User u, ProfileEditor editor, ProfileDbContext dbContext)
        {
            dbContext.Profiles.Add(new Profile(u, editor));
            await dbContext.SaveChangesAsync();
        }
    }
}
