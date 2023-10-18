using System.Linq;

namespace KingIT.Components;

/// <summary>
///     Логика взаимодействия для UserProfileCard.xaml
/// </summary>
public partial class UserProfileCard : EntityCard
{
    public UserProfileCard()
    {
        InitializeComponent();
        _Card = Card;
    }

    public override string? Name
    {
        set => _SetNamedCardField("UserName", value!);
    }

    public string? LastName
    {
        set => _SetNamedCardField("UserLastName", value!);
    }
    
    public string? MiddleName
    {
        set => _SetNamedCardField("UserMiddleName", value!);
    }

    public string? Email
    {
        set => _SetNamedCardField("UserEmail", value!);
    }
    
    public string? Password
    {
        set => _SetNamedCardField("UserPassword", value!);
    }

    public char RoleID
    {
        set => _SetNamedCardField("UserRole", BaseProvider.DbContext.Roles.Where(r => r.ID == value).First().ToString());
    }

    public string? PhoneNumber
    {
        set => _SetNamedCardField("UserPhoneNumber", value!);
    }
}