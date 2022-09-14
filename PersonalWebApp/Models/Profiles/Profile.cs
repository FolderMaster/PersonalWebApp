using System.Drawing;

using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Models.Profiles
{
    public class Profile
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Nick { get; set; }

        public string? Description { get; set; }

        public byte[]? Avatar { get; set; }

        public DateTime CreatedDate { get; set; }

        public Profile()
        {
        }

        public Profile(int id, int userId, string nick, string description, byte[]? avatar, DateTime
            createdDate)
        {
            Id = id;
            UserId = userId;
            Nick = nick;
            Description = description;
            Avatar = avatar;
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

        public Profile(User u, ProfileEditor editor)
        {
            UserId = u.Id;
            Nick = editor.Nick;
            Description = editor.Description;
            Avatar = editor.Avatar;
            CreatedDate = DateTime.Now;
        }
    }
}