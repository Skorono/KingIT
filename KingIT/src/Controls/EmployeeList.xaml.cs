using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class EmployeeList: CardList<Employee>
{
    public EmployeeList()
    {
        InitializeComponent();
        grid.Children.Add(ListArea);
    }
}