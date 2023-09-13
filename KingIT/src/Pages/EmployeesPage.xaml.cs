using System.Windows;
using System.Windows.Controls;

namespace KingIT.Pages;

public partial class EmployeesPage : Page
{
    public EmployeesPage()
    {
        InitializeComponent();
    }

    private void RefreshEmployee(object sender, RoutedEventArgs e)
    {
        EmpList.SetDoubleClickEvent(ToCardPage);
        EmpList.Update(BaseProvider.DbContext.Employees);
    }

    private void ToCardPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(null);
    }
}