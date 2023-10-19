using System.Windows.Controls;
using KingIT.ModelDB;

namespace KingIT.Pages;

public partial class PavillionEditingPage : Page
{
    private Employee Model { get; set; }
    
    private PavillionEditingPage()
    {
        InitializeComponent();
    }

    public PavillionEditingPage(Employee model)
    {
        Model = model;
    }
}