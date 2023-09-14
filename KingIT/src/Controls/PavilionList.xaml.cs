using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class PavilionList : CardList<Pavilion>
{
    public PavilionList()
    {
        InitializeComponent();
        grid.Children.Add(ListArea);
        SetCardView(new PavilionCard());
    }
}