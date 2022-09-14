using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Users
{
    public class UserLogin
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public UserLogin()
        {
        }

        public static async Task<User?> SignIn(UserLogin login, UserDbContext dbContext)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.Name == login.Name && user.Password == login.Password);
        }
    }
}
