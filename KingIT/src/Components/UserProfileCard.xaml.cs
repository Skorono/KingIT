using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Metadata;
using ViewControls;
using WpfLibrary.Components.Forms;
using WpfLibrary.Tools;

namespace KingIT.Components;

/// <summary>
///     Логика взаимодействия для UserProfileCard.xaml
/// </summary>
public partial class UserProfileCard : UserControl, IViewCard
{
    public UserProfileCard()
    {
        InitializeComponent();
    }

    public int ID { get; set; }

    public string? Name
    {
        set
        {
            var NameField = (TextBlock?)UIHelper.FindUid(Card.Children, "UserName");
            if (NameField != null) NameField.Text = value;
        }
    }
    
    public Item ItemCard => Card;
    public byte[] Photo
    {
        set => Card.ItemImage = ImageManager.LoadImage(value);
    }
}