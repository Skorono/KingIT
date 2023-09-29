using System.Windows.Controls;
using ViewControls;

namespace KingIT.Components;

public partial class ShoppingCenterCard : EntityCard
{
    public ShoppingCenterCard()
    {
        InitializeComponent();
        _Card = Card;
    }

    public override string? Name
    {
        set
        {
            var NameField = (TextBlock?)UIHelper.FindUid(Card.Children, "ShoppingCenterName");
            if (NameField != null) NameField.Text = value;
        }
    }
}