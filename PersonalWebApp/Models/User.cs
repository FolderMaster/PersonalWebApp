using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Nick { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public UserStatus Status { get; set; }

        public UserRights Rights { get; set; }

        public DateTime CreatedDate { get; set; }

        public User()
        { 
        }

        public User(string name, string password, UserStatus status, UserRights rights, DateTime createdDate)
        {
            Nick = name;
            Name = name;
            Password = password;
            Status = status;
            Rights = rights;
            CreatedDate = createdDate;
        }

        public User(int id, string nick, string name, string password, string phone,
            string email, UserStatus status, UserRights rights, DateTime createdDate)
        {
            Id = id;
            Nick = nick;
            Name = name;
            Password = password;
            Phone = phone;
            Email = email;
            Status = status;
            Rights = rights;
            CreatedDate = createdDate;
        }

        public enum UserStatus
        {
            None,
            Offline,
            Online
        }

        public enum UserRights
        {
            None,
            Standart,
            Modarator,
            Admin
        }
    }
}
