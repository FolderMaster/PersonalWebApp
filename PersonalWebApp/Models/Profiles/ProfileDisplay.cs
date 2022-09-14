using Microsoft.EntityFrameworkCore;
using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Models.Profiles
{
    public static class ProfileDisplay
    {
        public static async Task<Profile?> Display(string name, ProfileDbContext profileDb, UserDbContext userDb)
        {
            User? user = await UserDisplay.Display(name, userDb);
            if(user == null)
            {
                return null;
            }
            else
            {
                return await profileDb.Profiles.OrderByDescending(profile => profile.CreatedDate).
                    FirstOrDefaultAsync(profile => profile.UserId == user.Id);
            }
        }

        public static IAsyncEnumerable<Profile> DisplayAll(ProfileDbContext dbContext)
        {
            return dbContext.Profiles.AsAsyncEnumerable();
        }
    }
}