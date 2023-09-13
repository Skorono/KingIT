using System.Linq;
using System.Windows.Controls;
using KingIT.Controls;
using KingIT.ModelDB;

namespace KingIT.Pages;

public partial class EmployeePage : UserControl
{
    
    
    private ViewController<Employee> _viewController;
    public EmployeePage()
    {
        InitializeComponent();
    }

    public EmployeePage(int ID)
    {
        _viewController = new ViewController<Employee>(BaseProvider.DbContext.Employees.First(emp => emp.ID == ID));
        _viewController.SetView(this);
    }
}