using System.Windows.Controls;

namespace KingIT.Pages;

public partial class EditingPage: Page
{
    private object _targetEditObj = default!;    
    public EditingPage(object entity)
    {
        _targetEditObj = entity;
        InitializeComponent();
    }

    private void _parseObjectToEdit()
    {
        
    }
}