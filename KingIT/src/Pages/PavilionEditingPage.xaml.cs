using System.Windows.Controls;
using KingIT.ModelDB;

namespace KingIT.Pages;

public partial class PavilionEditingPage : Page
{
    private Pavilion Model { get; set; }
    
    private PavilionEditingPage()
    {
        InitializeComponent();
    }

    public PavilionEditingPage(Pavilion model)
    {
        Model = model;
    }
}