using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Models.Profiles
{
    public static class ProfileCreator
    {
        public static async Task Create(User user, ProfileDbContext dbContext)
        {
            dbContext.Profiles.Add(new Profile(user));
            await dbContext.SaveChangesAsync();
        }
    }
}