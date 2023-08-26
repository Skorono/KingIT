using KingIT.ModelDB;
using KingIT.Views;
using KingIT.Controls;
using System.Linq;
using System.Windows;
using KingIT.Interfaces;
using KingIT.Components;
using System.Windows.Controls;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KingIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewController<IUser> userController = default!;

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

        private Employee? GetEmployee()
        {
            return BaseProvider.DbContext.Employees.SingleOrDefault(emp => emp.Email == RegistrationArea.Login && emp.Password == RegistrationArea.Password);
        }

        private bool UserExists()
        {
            return GetEmployee() != null;
        }

        public void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            RegistrationArea.UserName = default!;
            Employee? Employee = GetEmployee();
            if (Employee != null)
                RegistrationArea.UserName = Employee.Name;
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
                return;
            }

            switch (emp.RoleID) {
                case UserTypes.Administrator:
                    {
                        userController = new Administrator(emp); break;
                    }
                case UserTypes.User:
                    {
                        userController = new User(emp); break;
                    }
                default: return;
            }

            var ListUsers = new List<UserControl>();
            foreach (var user in BaseProvider.DbContext.Employees)
            {
                ViewController<IUser> uController = new(user);
                var view = new UserProfileCard();
                uController.SetView<UserProfileCard>(view);
                ListUsers.Add(view);
            }
            List.ItemsSource = ListUsers;
        }
    }
}
