using System.Windows.Controls;
using ViewControls;
using WpfLibrary.Tools;

namespace KingIT.Components
{
    /// <summary>
    /// Логика взаимодействия для UserProfileCard.xaml
    /// </summary>
    public partial class UserProfileCard : UserControl
    {
        public string? Name {
            set => ((TextBlock)UIHelper.FindUid(Card.Children, "UserName")!).Text = value;
        }

        public byte[] Photo
        {
            set => Card.Image = ImageManager.LoadImage(value);
        }

        public UserProfileCard() => InitializeComponent();
    }
}
