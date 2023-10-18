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
    private EntityList? _entityCardList;
    private ViewController<IUser> _user;

    public MainPage(ViewController<IUser> user)
    {
        InitializeComponent();
        _user = user;
        ChangeFactory(new ShoppingCenterList());
    }

    private void Refresh(object sender, RoutedEventArgs e)
    {
        switch (_entityCardList.GetType().Name)
        {
            case ("EmployeeList"):
            {
                _entityCardList.Update(BaseProvider.DbContext.Employees.ToList());
                break;
            }
            
            case ("ShoppingCenterList"):
            {
                _entityCardList.Update(BaseProvider.DbContext.ShoppingCenters.ToList());
                break;
            }

        }
        //EmpList.Update(BaseProvider.DbContext.Employees);
    }

    private void Clicked()
    {
        switch (_entityCardList.GetType().Name)
        {
            case ("EmployeeCardList"):
            {
                ChangeFactory(new ShoppingCenterList());
                break;
            }
            case ("ShoppingCenterList"):
            {
                ChangeFactory(new EmployeeList());
                break;
            }
        }
    }

    private void ChangeFactory(EntityList entity)
    {
        _entityCardList = entity;
        _entityCardList.CardClicked += Clicked;
        ListBorder.Child = _entityCardList as UIElement;
        ListBorder.UpdateLayout();
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