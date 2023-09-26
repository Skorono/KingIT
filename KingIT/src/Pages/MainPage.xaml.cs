using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.Controls;

namespace KingIT.Pages;

public partial class MainPage : Page
{
    private CardList? EntityCardList = default!;
    private CardFactory? CurrentFactory = default!;
    public MainPage()
    {
        InitializeComponent();
        CurrentFactory = new EmployeeCardFactory();
        CurrentFactory.SetDoubleClickEvent(ToAuthPage);
        CurrentFactory.SetCardView(new UserProfileCard());
        EntityCardList = new CardList(CurrentFactory);
        ListBorder.Child = EntityCardList;
    }
    
    private void Refresh(object sender, RoutedEventArgs e)
    {
        EntityCardList.Update(BaseProvider.DbContext.Employees.ToList());
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