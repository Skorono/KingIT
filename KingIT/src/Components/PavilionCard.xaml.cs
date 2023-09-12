using System.Windows.Controls;
using WpfLibrary.Tools;

namespace KingIT.Components;

/// <summary>
///     Логика взаимодействия для PavilionCard.xaml
/// </summary>
public partial class PavilionCard : UserControl
{
    public PavilionCard()
    {
        InitializeComponent();
    }

    public byte[] Photo
    {
        set => Card.ItemImage = ImageManager.LoadImage(value);
    }

    public int FloorNumber { get; set; }
    public string Number { get; set; } = null!;
    public string StatusName { get; set; } = null!;
    public float Square { get; set; }
    public float AddedCoefficient { get; set; }
    public int Cost { get; set; }

    private void SetProperty(string property)
    {
    }
}