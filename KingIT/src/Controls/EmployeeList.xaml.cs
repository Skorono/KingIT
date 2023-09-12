using System.Windows;
using KingIT.Components;
using KingIT.Interfaces;

namespace KingIT.Controls;

public partial class EmployeeList
{
    private RoutedEventHandler _doubleClickEvent;
    public EmployeeList()
    {
        InitializeComponent();
    }

    public void Update()
    {
        foreach (var emp in BaseProvider.DbContext.Employees)
        {
            if (ListArea.Exists(card => (card as UserProfileCard).ID == emp.ID))
                continue;

            var viewController = new ViewController<IUser>(emp);
            var card = new UserProfileCard();
            viewController.SetView(card);
            card.Card.DoubleClick += _doubleClickEvent;
            ListArea.Add(card);
        }
    }
    
    public void SetDoubleClickEvent(RoutedEventHandler newEvent)
    {
        _doubleClickEvent = newEvent;
    }
}