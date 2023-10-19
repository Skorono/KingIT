using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class EmployeeList: EntityList
{
    public UserProfileCard CardView
    {
        set => _listCardFactory.SetCardView(value);
    }

    public EmployeeList()
    {
        InitializeComponent();
        _listCardFactory = new EmployeeCardFactory();
        CardView = new UserProfileCard();
        _listCardFactory.SetDoubleClickEvent(OnCardDoubleClick);
    }


    public override void Update<T>(List<T> data)
    {
        Area.Clear();
        data.ForEach(d => Area.Add(_listCardFactory.Make(d) as UIElement));
    }

    /*public override void OnCardDoubleClick(object sender, EventArgs e)
    {
        CardClicked.Invoke();
    }*/

    private void OnSearch(object sender, RoutedEventArgs e)
    {
        Update<Employee>(BaseProvider.DbContext.Employees.ToList());
        Area.Sort(card => (card as UserProfileCard)!.LastName == SearchText.Text);
    }
}
