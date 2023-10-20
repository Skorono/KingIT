using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using KingIT.EntitiesStatus;
using KingIT.Pages;

namespace KingIT.Components;

/// <summary>
///     Логика взаимодействия для PavilionCard.xaml
/// </summary>
public partial class PavilionCard : EntityCard
{
    public PavilionCard()
    {
        InitializeComponent();
        _Card = Card;
    }
    public char StatusID { get; set; }
    public int ID { get; set; }
    public int FloorNumber
    {
        set => _SetNamedCardField("FloorNumber", value.ToString());
    }
    public string StatusName
    {
        set => BaseProvider.DbContext.PavilionStatuses.First(s => s.ID == StatusID);
    }
    public float Square
    {
        set => _SetNamedCardField("Square", value.ToString());
    }
    public float AddedCoefficient
    {
        set => _SetNamedCardField("AddedCoefficient", value.ToString());
    }
    public int Cost
    {
        set => _SetNamedCardField("Cost", value.ToString());
    }

    public override string? Name
    {
        set => _SetNamedCardField("PavilionName", value);
    }

    protected override void DeleteItem(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот павильон?", "Удаление",
            MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
            var pavilion = BaseProvider.DbContext.Pavilions.First(p => p.ID == ID);
            pavilion.Status = BaseProvider.DbContext.PavilionStatuses.First(status => status.ID == PavilionStatuses.Deleted);
            BaseProvider.DbContext.Pavilions.Update(pavilion);
            BaseProvider.DbContext.SaveChangesAsync();
        }
    }

    protected override void ToEditPage(object sender, RoutedEventArgs e)
    {
        NavigationService.GetNavigationService(this)
            .Navigate(new PavilionEditingPage(BaseProvider.DbContext.Pavilions.First(p => p.ID == ID)));
    }
}