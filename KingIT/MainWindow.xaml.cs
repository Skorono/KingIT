using KingIT.EntitiesStatus;
using KingIT.ModelDB;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace KingIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegistrationArea.OnRegistrationClick += ToRegistrationPage;
            RegistrationArea.OnAuthEvent += AuthAction;
            RegistrationArea.OnPasswordEnter += OnPasswordChanged;
        }

        public void ToRegistrationPage(object sender, RoutedEventArgs e)
        {
            //NavigationService.GetNavigationService(this).Navigate();
        }

        public void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var Employee = BaseProvider.DbContext.Employees.Where(emp => emp.Email == RegistrationArea.Login && emp.Password == RegistrationArea.Password).FirstOrDefault();
            if (Employee != null)
                RegistrationArea.UserName = Employee.Name;
        }

        public void AuthAction(object sender, RoutedEventArgs e)
        {
            var User = new Employee { 
                Email = RegistrationArea.Login, 
                Password = RegistrationArea.Password,
                Name = RegistrationArea.UserName,
                Role = BaseProvider.DbContext.Roles.Where(r => r.ID == UserTypes.User).First(), 
                Status = BaseProvider.DbContext.UserStatuses.Where(r => r.ID == AccountStatuses.Active).First()
            };

            BaseProvider.DbContext.Employees.Add(User);
            BaseProvider.DbContext.SaveChanges();
        }
    }
}
