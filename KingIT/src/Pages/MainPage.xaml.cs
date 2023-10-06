using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.Controls;
using KingIT.Interfaces;

namespace KingIT.Pages;

public partial class MainPage : Page
{
    private CardFactory? _currentFactory;
    private readonly ICardList? _entityCardList;
    private ViewController<IUser> _user;

    public MainPage(ViewController<IUser> user)
    {
        InitializeComponent();
        _user = user;
        _currentFactory = new ShoppingCenterCardFactory();
        _currentFactory.SetDoubleClickEvent(ToEmployeeList);
        _currentFactory.SetCardView(new ShoppingCenterCard());
        _entityCardList = new ShoppingCenterList();
        ListBorder.Child = _entityCardList as UIElement;
    }

    private void Refresh(object sender, RoutedEventArgs e)
    {
        switch (_currentFactory.GetType().Name)
        {
            case ("EmployeeCardFactory"):
            {
                _entityCardList.Update(BaseProvider.DbContext.Employees.ToList());
                break;
            }
            
            case ("ShoppingCenterCardFactory"):
            {
                _entityCardList.Update(BaseProvider.DbContext.ShoppingCenters.ToList());
                break;
            }

        }
        //EmpList.Update(BaseProvider.DbContext.Employees);
    }

    private void ToCardPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(null);
    }

    private void ToEmployeeList(object sender, RoutedEventArgs e)
    {
        _currentFactory = new EmployeeCardFactory();
        _currentFactory.SetCardView(new UserProfileCard());
        _currentFactory.SetDoubleClickEvent(ToAuthPage);
        //_entityCardList.SetCardFactory(_currentFactory);
        Refresh(this, null);
    }

    private void ToAuthPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(null);
    }
}