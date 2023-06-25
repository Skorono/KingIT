using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace KingIT.ModelDB
{
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Name { get; set; } = null!;

        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string? LastName { get; set; } = null!;

        public string? MiddleName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [PasswordPropertyText]
        public string Password { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        public byte[]? Photo { get; set; }

        public bool? Gender { get; set; }

        public UserStatus Status { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
