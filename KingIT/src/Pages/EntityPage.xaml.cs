using System.Windows.Controls;
using KingIT.Controls;

namespace KingIT.Pages;

public partial class EntityPage : UserControl
{
    private object _viewModelController;

    public bool isAdmin
    {
        get
        {
            return nameof(_viewModelController).CompareTo("Admin") > 0;
        }

        private set { }
    }

    public bool isManager
    {
        get
        {
            return nameof(_viewModelController).CompareTo("ManagerC") > 0;
        }

        private set { }
    }
    
    public EntityPage()
    {
        InitializeComponent();
    }

    public EntityPage(ViewController<object> entity)
    {
        _viewModelController = entity;
        /*_viewController = new ViewController<Employee>(BaseProvider.DbContext.Employees.First(emp => emp.ID == ID));
        _viewController.SetView(this);*/
    }
}