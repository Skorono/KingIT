using System;
using System.Windows.Navigation;

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
        Card.DoubleClick += ToEmployeeList;
    }

    public int ID { get; set; }
    public int FloorNumber { get; set; }
    public string Number { get; set; } = null!;
    public string StatusName { get; set; } = null!;
    public float Square { get; set; }
    public float AddedCoefficient { get; set; }
    public int Cost { get; set; }

    public override string? Name
    {
        set => throw new NotImplementedException();
    }

    private void SetProperty(string property)
    {
    }

    private void ToEmployeeList(object sender, EventArgs e)
    {
        NavigationService.GetNavigationService(this).Navigate(null);
    }
}