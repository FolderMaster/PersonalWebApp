using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Users
{
    public class UserRegistration
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public UserRegistration()
        {
        }

        public static async Task<User?> Register(UserRegistration registration, UserDbContext dbContext)
        {
            User? user = await dbContext.Users.FirstOrDefaultAsync(user => user.Name == registration.Name);
            if (user != null)
            {
                return null;
            }
            else
            {
                dbContext.Users.Add(new User(registration));
                await dbContext.SaveChangesAsync();
                return await dbContext.Users.FirstOrDefaultAsync(user => user.Name == registration.Name);
            }
        }
    }
}
