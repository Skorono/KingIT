using System.Linq;
using System.Windows;
using KingIT.Components;
using KingIT.Controls;
using KingIT.Interfaces;
using KingIT.ModelDB;
using KingIT.Views;
using WpfLibrary;
using WpfLibrary.Components.Auth;

namespace KingIT;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private int _authTryNumber;
    private ViewController<IUser>? _userController;

    public MainWindow()
    {
        InitializeComponent();
        RegistrationArea.OnRegistrationClick += ToRegistrationPage;
        RegistrationArea.OnAuthEvent += AuthAction;
        RegistrationArea.OnPasswordEnter += OnPasswordChanged;
    }

    private void ToRegistrationPage(object sender, RoutedEventArgs e)
    {
        //NavigationService.GetNavigationService(this).Navigate();
    }

    private Employee? GetEmployee()
    {
        return BaseProvider.DbContext.Employees.SingleOrDefault(emp =>
            emp.Email == RegistrationArea.Login && emp.Password == RegistrationArea.Password);
    }

    private bool UserExists()
    {
        return GetEmployee() != null;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        RegistrationArea.UserName = default!;
        var employee = GetEmployee();
        if (employee != null)
            RegistrationArea.UserName = employee.Name;
    }

    private void OnAuthFailed()
    {
        var validator = new ObjValidator<AuthFirstForm>(RegistrationArea);
        if (!(validator.isValid(RegistrationArea.Login, nameof(RegistrationArea.Login))
              && validator.isValid(RegistrationArea.Password, nameof(RegistrationArea.Password))))
            MessageBox.Show("Проверьте формат введенных данных");
        else
            MessageBox.Show("Неверный логин или пароль");

        if (++_authTryNumber >= 3)
        {
            var capcha = new Capcha(new Capcha.CapchaArgs
            {
                Layout = MainGrid,
                Vertical = VerticalAlignment.Center,
                Horizontal = HorizontalAlignment.Center
            });
            capcha.Show();
        }
    }

    private void AuthAction(object sender, RoutedEventArgs e)
    {
        /*var User = new Employee { 
            Email = RegistrationArea.Login, 
            Password = RegistrationArea.Password,
            Name = RegistrationArea.UserName,
            Role = BaseProvider.DbContext.Roles.Where(r => r.ID == UserTypes.User).First(), 
            Status = BaseProvider.DbContext.UserStatuses.Where(r => r.ID == AccountStatuses.Active).First()
        };*/

        IUser? emp = GetEmployee();
        if (emp == null)
        {
            OnAuthFailed();
            return;
        }

        switch (emp.RoleID)
        {
            case UserTypes.Administrator:
            {
                _userController = new Administrator(emp);
                break;
            }
            case UserTypes.User:
            {
                _userController = new User(emp);
                break;
            }
            default: return;
        }

        if (_userController != null) MainFrame.Navigate(null);
    }
}