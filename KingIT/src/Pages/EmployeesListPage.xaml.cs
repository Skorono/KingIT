using System.Windows;
using System.Windows.Controls;
using KingIT.Components;

namespace KingIT.Pages;

public partial class EmployeesListPage : Page
{
    public EmployeesListPage()
    {
        InitializeComponent();
        EmpList.SetCardView(new UserProfileCard());
        EmpList.SetDoubleClickEvent(ToCardPage);
    }
    
    private void RefreshEmployee(object sender, RoutedEventArgs e)
    {
        EmpList.Update(BaseProvider.DbContext.Employees);
    }

    private void ToCardPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(null);
    }

    private void ToAuthPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(null);
    }
}