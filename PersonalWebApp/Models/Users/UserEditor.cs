using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Users
{
    public class UserEditor
    {
        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public UserEditor()
        {
        }

        public static async Task<User?> Edit(User u, UserEditor editor, UserDbContext dbContext)
        {
            User? user = await dbContext.Users.FirstOrDefaultAsync(user => user.Name == u.Name && user.Password == u.Password);
            if (user == null)
            {
                return null;
            }
            else
            {
                user.Password = editor.Password;
                user.Phone = editor.Phone;
                user.Email = editor.Email;
                await dbContext.SaveChangesAsync();
                return await dbContext.Users.FirstOrDefaultAsync(user => user.Name == u.Name && user.Password == u.Password);
            }
        }
    }
}
