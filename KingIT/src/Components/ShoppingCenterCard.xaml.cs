using System.IO;
using System.Windows.Controls;
using ViewControls;
using WpfLibrary.Components.Forms;
using WpfLibrary.Tools;

namespace KingIT.Components;

public partial class ShoppingCenterCard : UserControl, IViewCard
{
    public Item? ItemCard => Card;
    
    public string? Name
    {
        set
        {
            var NameField = (TextBlock?)UIHelper.FindUid(Card.Children, "ShoppingCenterName");
            if (NameField != null) NameField.Text = value;
        }
    }
    
    public string? Photo
    {
        set => Card.ItemImage = ImageManager.LoadImage(ImageManager.Upload(Path.GetRelativePath(App.ResourceAssembly.Location, value)));
    }

    public ShoppingCenterCard()
    {
        InitializeComponent();
    }
}