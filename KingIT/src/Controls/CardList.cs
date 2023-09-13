using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using Microsoft.EntityFrameworkCore;

namespace KingIT.Controls;

public class CardList<T>: UserControl where T: class 
{
    private RoutedEventHandler? _doubleClickEvent;
    private HashSet<IViewCard> _elementList = default!;
    private Type _cardViewType;
    
    public CardList()
    {
        
    }

    public virtual void Update(DbSet<T> dbSource)
    {
        foreach (var pav in dbSource)
        {
            var viewcontroller = new ViewController<T>(pav);
            var card = (IViewCard)Activator.CreateInstance(_cardViewType)!;
            viewcontroller.SetView((UserControl)card);
            card.ItemCard.DoubleClick += _doubleClickEvent;
            _elementList.Add(card);
        }
    }

    public void SetCardView(IViewCard cardType)
    {
        _cardViewType = cardType.GetType();
    }
    
    public void SetDoubleClickEvent(RoutedEventHandler newEvent)
    {
        _doubleClickEvent = newEvent;
    }
}