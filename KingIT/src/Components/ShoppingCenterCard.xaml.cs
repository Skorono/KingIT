using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using KingIT.EntitiesStatus;
using KingIT.Pages;

namespace KingIT.Components;

public partial class ShoppingCenterCard : EntityCard
{
    public ShoppingCenterCard()
    {
        InitializeComponent();
        _Card = Card;
    }

    public override string? Name
    {
        set => _SetNamedCardField("ShoppingCenterName", value);
    }

    protected override void DeleteItem(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот торговый центр?", "Удаление",
            MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
            var center = BaseProvider.DbContext.ShoppingCenters.First(c => c.ID == ID);
            center.StatusID =
                BaseProvider.DbContext.ShoppingCenterStatuses.First(status =>
                    status.ID == ShoppingCenterStatuses.Deleted).ID;
            BaseProvider.DbContext.ShoppingCenters.Update(center);
            BaseProvider.DbContext.SaveChangesAsync();
        }
    }

    protected override void ToEditPage(object sender, RoutedEventArgs e)
    {
        NavigationService.GetNavigationService(this)
            .Navigate(new ShoppingCenterEditingPage());
    }

    public int StatusID { get; set; }

    public string StatusName
    {
        get => BaseProvider.DbContext.ShoppingCenterStatuses.First(status => status.ID == StatusID).Name;
    }
    
    public int Cost
    {
        set => _SetNamedCardField("Cost", value.ToString());
    }

    public float AddedCoefficient
    {
        set => _SetNamedCardField("AddedCoefficient", value.ToString());

    }

    public int FloorsCount
    {
        set => _SetNamedCardField("FloorsCount", value.ToString());
    }
}