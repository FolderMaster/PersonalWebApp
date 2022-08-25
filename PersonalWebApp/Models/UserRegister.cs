using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models
{
    public class UserRegister
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public UserRegister()
        {
        }

        public UserRegister(string name, string password, string confirmPassford)
        {
            Name = name;
            Password = password;
            ConfirmPassword = confirmPassford;
        }

        public static async void Registrater(UserRegister registration, UserDbContext dbContext)
        {
            User? user = dbContext.Users.FirstOrDefault(user => user.Name == registration.Name);
            if(user != null)
            {
                throw new Exception();
            }
            else
            {
                dbContext.Users.Add(new User(registration.Name, registration.Password, User.UserStatus.None, User.UserRights.None, DateTime.Now));
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
