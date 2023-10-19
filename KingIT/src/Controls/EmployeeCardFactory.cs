using System;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public class EmployeeCardFactory : CardFactory
{
    public EmployeeCardFactory()
    {
        SetCardView(new UserProfileCard());
    }

    public override IViewCard Make(object model)
    {
        var viewcontroller = new ViewController<Employee>((Employee)model);
        var card = (EntityCard)Activator.CreateInstance(_cardViewType)!;
        viewcontroller.SetView((UserControl)card);
        card.ItemCard.DoubleClick += _doubleClickEvent;
        card.OnEdit = OnEdit;
        return card;
    }
}