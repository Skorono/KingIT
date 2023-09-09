using System.Windows;
using ViewControls.Controls;
using System.Windows.Controls;

namespace KingIT.Pages;

public partial class EmployeesPage : Page
{
    public EmployeesPage()
    {
        InitializeComponent();
    }

    private void RefreshEmployee(object sender, RoutedEventArgs e) => EmpList.Update();
}