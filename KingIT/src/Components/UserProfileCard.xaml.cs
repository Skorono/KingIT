using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KingIT.EntitiesStatus;
using ViewControls;

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

    public int ID { get; set; }
    public override string? Name
    {
        set => _SetNamedCardField("UserName", value!);
    }

    public string? LastName
    {
        set => _SetNamedCardField("UserLastName", value!);
        get => ((TextBlock?)UIHelper.FindUid(_Card.Children, "UserLastName"))?.Text;

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

    private void ToEditPage(object sender, RoutedEventArgs e)
    {
        OnEdit.Invoke(this, null);
        //NavigationService.GetNavigationService(this).Navigate(new UserEditingPage());
    }


    private void DeleteItem(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?", "Удаление",
            MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
            var emp = BaseProvider.DbContext.Employees.First(emp => emp.ID == ID);
            emp.Status = BaseProvider.DbContext.UserStatuses.First(status => status.ID == AccountStatuses.Deleted);
            BaseProvider.DbContext.Employees.Update(emp);
            BaseProvider.DbContext.SaveChangesAsync();
        }
    }
}