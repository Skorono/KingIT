using System.Windows.Controls;
using ViewControls;

namespace KingIT.Components;

/// <summary>
///     Логика взаимодействия для UserProfileCard.xaml
/// </summary>
public partial class UserProfileCard : EntityCard
{
    public UserProfileCard()
    {
        InitializeComponent();
        _Card = Card;
    }

    public int ID { get; set; }

    public override string? Name
    {
        set
        {
            var NameField = (TextBlock?)UIHelper.FindUid(Card.Children, "UserName");
            if (NameField != null) NameField.Text = value;
        }
    }
}