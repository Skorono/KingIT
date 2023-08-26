using KingIT.ModelDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KingIT.Interfaces
{
    public interface IUser
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } 

        public string? PhoneNumber { get; set; }

        public byte[]? Photo { get; set; }

        public bool Gender { get; set; }

        public char RoleID { get; set; }

        public UserStatus Status { get; set; }
        public Role Role { get; set; }
    }
}
