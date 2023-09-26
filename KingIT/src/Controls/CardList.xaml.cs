using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KingIT.Components;
using KingIT.ModelDB;
using Microsoft.EntityFrameworkCore;

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

    public void Update(List<Employee> data)
    {
        foreach (var card in data)
            ListArea.Add((UserControl)EntityCardFactory.Make(card));
    }
}