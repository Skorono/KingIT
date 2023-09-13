using System;
using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using Microsoft.EntityFrameworkCore;
using ViewControls.Controls;
using WpfLibrary.Components.Forms;

namespace KingIT.Controls;

public class CardList<T>: UserControl where T: class 
{
    protected RoutedEventHandler? _doubleClickEvent;
    protected Type _cardViewType = typeof(Item);
    protected UIArea ListArea = new UIArea();
    
    protected CardList()
    {
    }
    
    public CardList(IViewCard cardType)
    {
        SetCardView(cardType);
    }

    public virtual void Update(DbSet<T> dbSource)
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
    }

    public virtual void SetCardView(IViewCard cardType)
    {
        _cardViewType = cardType.GetType();
    }
    
    public virtual void SetDoubleClickEvent(RoutedEventHandler newEvent)
    {
        _doubleClickEvent = newEvent;
    }
}