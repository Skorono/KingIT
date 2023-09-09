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
        public int ID { get; set; }

        public string? Name
        {
            set
            {
                TextBlock? NameField = (TextBlock?)UIHelper.FindUid(Card.Children, "UserName"); 
                if (NameField != null ) NameField.Text = value;
            }
        }
        
        public byte[] Photo
        {
            set => Card.ItemImage = ImageManager.LoadImage(value);
        }

        public UserProfileCard() => InitializeComponent();
    }
}
