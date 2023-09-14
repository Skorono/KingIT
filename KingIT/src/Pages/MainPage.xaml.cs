using System.Windows;
using System.Windows.Controls;

namespace KingIT.Pages;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    private void RefreshEmployee(object sender, RoutedEventArgs e)
    {
        //EmpList.Update(BaseProvider.DbContext.Employees);
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