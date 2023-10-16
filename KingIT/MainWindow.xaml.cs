using System.Linq;
using System.Windows;
using KingIT.Components;
using KingIT.Controls;
using KingIT.Interfaces;
using KingIT.ModelDB;
using KingIT.Pages;
using KingIT.Views;
using WpfLibrary;
using WpfLibrary.Components.Auth;

namespace KingIT;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int AuthTryNumber;
    private ViewController<IUser>? userController;

    public MainWindow()
    {
        InitializeComponent();
        RegistrationArea.OnRegistrationClick += ToRegistrationPage;
        RegistrationArea.OnAuthEvent += AuthAction;
        RegistrationArea.OnPasswordEnter += OnPasswordChanged;
        RegistrationArea.Click += ToRegistrationPage;
    }

    public void ToRegistrationPage(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Регистрация не запланирована :)");
    }

    private Employee? GetEmployee()
    {
        return BaseProvider.DbContext.Employees.SingleOrDefault(emp =>
            emp.Email == RegistrationArea.Login.ToLower() && emp.Password == RegistrationArea.Password);
    }

    private bool UserExists()
    {
        return GetEmployee() != null;
    }

    public void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        RegistrationArea.UserName = default!;
        var Employee = GetEmployee();
        if (Employee != null)
            RegistrationArea.UserName = Employee.Name;
    }

    public void OnAuthFailed()
    {
        var validator = new ObjValidator<AuthFirstForm>(RegistrationArea);
        if (!(validator.isValid(RegistrationArea.Login, nameof(RegistrationArea.Login))
              && validator.isValid(RegistrationArea.Password, nameof(RegistrationArea.Password))))
            MessageBox.Show("Проверьте формат введенных данных");
        else
            MessageBox.Show("Неверный логин или пароль");

        if (++AuthTryNumber >= 3)
        {
            var capcha = new Capcha(new Capcha.CapchaArgs
            {
                Layout = MainGrid,
                Vertical = VerticalAlignment.Center,
                Horizontal = HorizontalAlignment.Center,
                CulumnNumber = 1,
                RowNumber = 1
            });
            capcha.Show();
        }
    }

    public void AuthAction(object sender, RoutedEventArgs e)
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
                userController = new Administrator(emp);
                break;
            }
            case UserTypes.ManagerA:
            {
                userController = new ManagerA(emp);
                break;
            }
            case UserTypes.ManagerC:
            {
                userController = new ManagerC(emp);
                break;
            }
            default: return;
        }

        if (userController != null) MainFrame.Navigate(new MainPage(userController));
    }
}