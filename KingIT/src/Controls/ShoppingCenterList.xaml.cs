using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class ShoppingCenterList : EntityList
{
    public ShoppingCenterCard CardView
    {
        set => _listCardFactory.SetCardView(value);
    }

    public ShoppingCenterList()
    {
        InitializeComponent();
        _listCardFactory = new ShoppingCenterCardFactory();
        CardView = new ShoppingCenterCard();
        _listCardFactory.SetDoubleClickEvent(OnCardDoubleClick);
        TownSelecter.ItemsSource = BaseProvider.DbContext.Towns.Select(town => town.Name).ToList();
        StatusSelecter.ItemsSource = BaseProvider.DbContext.ShoppingCenterStatuses.Select(center => center.Name).ToList();
    }


    public override void Update<T>(List<T> data)
    {
        Area.Clear();
        data.ForEach(d => Area.Add(_listCardFactory.Make(d) as UIElement));
    }

    /*public override void OnCardDoubleClick(object sender, EventArgs e)
    {
        CardClicked.Invoke();
    }*/
    private void SortTown(object sender, RoutedEventArgs e)
    {
        Update<ShoppingСenter>(BaseProvider.DbContext.ShoppingCenters.ToList());
        Area.Sort(card => BaseProvider.DbContext.ShoppingCenters.First(center => center.ID == (card as ShoppingCenterCard).ID).TownID == BaseProvider.DbContext.Towns.First(t => t.Name == TownSelecter.SelectedItem.ToString()).ID);
    }

    private void SortStatus(object sender, RoutedEventArgs e)
    {
        Area.Sort(card =>  (card as ShoppingCenterCard)!.StatusName == StatusSelecter.SelectedItem.ToString());
    }
}