using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class PavilionList : UserControl
{
    private RoutedEventHandler _doubleClickEvent;
    
    public PavilionList()
    {
        InitializeComponent();
    }

    /*public void Update()
    {
        foreach (var pav in BaseProvider.DbContext.Pavilions)
        {
            if (ListArea.Exists(card => (card as PavilionCard)!.ID == emp.ID))
                continue;
            
            var viewcontroller = new ViewController<Pavilion>(pav);
            PavilionCard card = new PavilionCard();
            viewcontroller.SetView(card);
            ListArea.Add(card);
        }
    }*/
    
    public void SetDoubleClickEvent(RoutedEventHandler newEvent)
    {
        _doubleClickEvent = newEvent;
    }
}