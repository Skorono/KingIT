using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.Controls;
using KingIT.Interfaces;

namespace KingIT.Pages;

public partial class MainPage : Page
{
    private ViewController<IUser> _user;
    private CardList? _entityCardList = default!;
    private CardFactory? _currentFactory = default!;
    public MainPage(ViewController<IUser> user)
    {
        InitializeComponent();
        _user = user;
        _currentFactory = new ShoppingCenterCardFactory();
        _currentFactory.SetDoubleClickEvent(ToAuthPage);
        _currentFactory.SetCardView(new ShoppingCenterCard());
        _entityCardList = new CardList(_currentFactory);
        ListBorder.Child = _entityCardList;
    }
    
    private void Refresh(object sender, RoutedEventArgs e)
    {
        _entityCardList.Update(BaseProvider.DbContext.ShoppingCenters.ToList());
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