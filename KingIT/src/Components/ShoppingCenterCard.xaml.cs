using System.Windows.Controls;
using WpfLibrary.Components.Forms;

namespace KingIT.Components;

public partial class ShoppingCenterCard : UserControl, IViewCard
{
    public Item? ItemCard => null; 

    public ShoppingCenterCard()
    {
        InitializeComponent();
    }
}