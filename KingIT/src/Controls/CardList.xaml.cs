using System.Collections.Generic;
using System.Windows.Controls;

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

    public void SetCardFactory(CardFactory cardFactory)
    {
        EntityCardFactory = cardFactory;
    }

    public void Update<T>(List<T> data) where T: new()
    {
        ListArea.Clear();
        foreach (var card in data)
            ListArea.Add((UserControl)EntityCardFactory.Make(card));
    }
}