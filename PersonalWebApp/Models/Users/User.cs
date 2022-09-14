using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace PersonalWebApp.Models.Users
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public UserStatus Status { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedDate { get; set; }

        public User()
        {
        }

        public User(int id, string name, string password, string? phone, string? email, UserStatus
            status, UserRole role, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Password = password;
            Phone = phone;
            Email = email;
            Status = status;
            Role = role;
            CreatedDate = createdDate;
        }

        public User(UserRegistration registration)
        {
            Name = registration.Name;
            Password = registration.Password;
            Status = UserStatus.None;
            Role = UserRole.None;
            CreatedDate = DateTime.Now;
        }

        public enum UserStatus
        {
            None,
            Offline,
            Online
        }

        public enum UserRole
        {
            None,
            Standart,
            Modarator,
            Admin
        }
    }
}
