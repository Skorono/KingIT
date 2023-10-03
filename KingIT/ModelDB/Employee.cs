using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KingIT.Interfaces;

namespace KingIT.ModelDB;

public class Employee : Model, IUser
{
    public int ID { get; set; }

    [StringLength(50, MinimumLength = 4)] public string Name { get; set; } = null!;

    [StringLength(50, MinimumLength = 4)] public string? LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    [EmailAddress] public string Email { get; set; } = null!;

    [PasswordPropertyText] public string Password { get; set; } = null!;

    [Phone] public string? PhoneNumber { get; set; }

    public string? Photo { get; set; }

    public bool Gender { get; set; }

    public char RoleID { get; set; }

    public UserStatus Status { get; set; } = null!;
    public Role Role { get; set; } = null!;

    public override event UpdatedDataDelegate? Changed;
    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    //public override void Update() => Changed.Invoke(BaseProvider.DbContext.Employees);
}