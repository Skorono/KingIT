using System;
using System.Windows;
using KingIT.Components;

namespace KingIT.Controls;

public abstract class CardFactory
{
    protected Type _cardViewType;
    protected RoutedEventHandler? _doubleClickEvent;
    protected EventHandler _onEdit;
    public EventHandler? OnEdit;

    public abstract IViewCard Make(object model);


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

    public virtual void SetOnEditAction(EventHandler action)
    {
        _onEdit = action;
    }
}