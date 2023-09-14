using System;
using System.Windows;
using KingIT.Components;

namespace KingIT.Controls;

public abstract class CardFactory 
{
    protected RoutedEventHandler? _doubleClickEvent;
    protected Type _cardViewType = default;
    public abstract IViewCard MakeCard(object model);
    

    /*public virtual void Update(DbSet<T> dbSource)
    {
        ListArea.Clear();
        foreach (var el in dbSource)
        {
            var viewcontroller = new ViewController<T>(el);
            var card = (IViewCard)Activator.CreateInstance(_cardViewType)!;
            viewcontroller.SetView((UserControl)card);
            card.ItemCard.DoubleClick += _doubleClickEvent;
            ListArea.Add((UIElement)card);
        }
    }*/
    
    

    public virtual void SetCardView(IViewCard cardType)
    {
        _cardViewType = cardType.GetType();
    }
    
    public virtual void SetDoubleClickEvent(RoutedEventHandler newEvent)
    {
        _doubleClickEvent = newEvent;
    }
}