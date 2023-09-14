using System;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public class PavilionCardFactory : CardFactory
{
    
    public PavilionCardFactory()
    {
        SetCardView(new PavilionCard());
    }
    public override IViewCard MakeCard(object model)
    {
        var viewcontroller = new ViewController<Pavilion>((Pavilion)model);
        var card = (IViewCard)Activator.CreateInstance(_cardViewType)!;
        viewcontroller.SetView((UserControl)card);
        card.ItemCard.DoubleClick += _doubleClickEvent;
        return card;
    }
}