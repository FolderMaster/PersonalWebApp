using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Users
{
    public class UserDisplay
    {
        public static async Task<User?> Display(string name, UserDbContext dbContext)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.Name == name);
        }

        public static IAsyncEnumerable<User> DisplayAll(UserDbContext dbContext)
        {
            return dbContext.Users.AsAsyncEnumerable();
        }
    }
}
