using System.Collections.Generic;
using System.Windows.Controls;
using KingIT.ModelDB;

namespace KingIT.Controls;

public partial class CardList : UserControl
{
    private CardFactory EntityCardFactory;
    public CardList(CardFactory cardFactory)
    {
        EntityCardFactory = cardFactory;
        InitializeComponent();
    }

    public CardList()
    {
        InitializeComponent();
    }

    public void Update(List<ShoppingСenter> data)
    {
        foreach (var card in data)
            ListArea.Add((UserControl)EntityCardFactory.Make(card));
    }
}