using Microsoft.EntityFrameworkCore;

using PersonalWebApp.Models.Users;
using PersonalWebApp.Models.Files;

using File = PersonalWebApp.Models.Files.File;

namespace PersonalWebApp.Models.Profiles
{
    public class Profile
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Nick { get; set; }

        public string? Description { get; set; }

        public int? Avatar { get; set; }

        public DateTime CreatedDate { get; set; }

        public Profile()
        {
        }

        public Profile(int id, int userId, string nick, string description, int avatarId, DateTime
            createdDate)
        {
            Id = id;
            UserId = userId;
            Nick = nick;
            Description = description;
            Avatar = avatarId;
            CreatedDate = createdDate;
        }

        public Profile(User user)
        {
            UserId = user.Id;
            Nick = user.Name;
            Description = "";
            Avatar = null;
            CreatedDate = DateTime.Now;
        }

        public Profile(User u, ProfileEditor editor, IWebHostEnvironment webHostEnvironment,
            FileDbContext fileContext)
        {
            UserId = u.Id;
            Nick = editor.Nick;
            Description = editor.Description;

            File? file = FileUploader.Upload(editor.Avatar, webHostEnvironment, fileContext).Result;
            if(file == null)
            {
                Avatar = null;
            }
            else
            {
                Avatar = file.Id;
            }

            CreatedDate = DateTime.Now;
        }
    }
}