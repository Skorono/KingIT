using System.Windows;
using KingIT.Components;
using KingIT.Interfaces;
using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class EmployeeList: CardList<Employee>
{
    public EmployeeList()
    {
        InitializeComponent();
    }
}