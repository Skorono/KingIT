using System;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public class ShoppingCenterCardFactory : CardFactory
{
    public override IViewCard Make(object model)
    {
        var viewcontroller = new ViewController<ShoppingСenter>((ShoppingСenter)model);
        var card = (IViewCard)Activator.CreateInstance(_cardViewType)!;
        viewcontroller.SetView((UserControl)card);
        card.ItemCard.DoubleClick += _doubleClickEvent;
        return card;
    }
}