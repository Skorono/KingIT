using System.Collections.Generic;
using System.Linq;
using ViewControls.Controls;
using KingIT.Components;
using KingIT.Interfaces;
using KingIT.Views;

namespace KingIT.Controls;
public partial class EmployeeList
{
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
            UserProfileCard card = new UserProfileCard();
            viewController.SetView(card);
            ListArea.Add(card);
        }    
    }
}