using System;
using System.Collections.Generic;
using System.Windows;
using KingIT.Components;

namespace KingIT.Controls;

public partial class ShoppingCenterList : EntityList
{
    public ShoppingCenterCard CardView
    {
        set => _listCardFactory.SetCardView(value);
    }

    public ShoppingCenterList()
    {
        InitializeComponent();
        _listCardFactory = new ShoppingCenterCardFactory();
        CardView = new ShoppingCenterCard();
        _listCardFactory.SetDoubleClickEvent(OnCardDoubleClick);
    }


    public override void Update<T>(List<T> data)
    {
        Area.Clear();
        data.ForEach(d => Area.Add(_listCardFactory.Make(d) as UIElement));
    }

    public override void OnCardDoubleClick(object sender, EventArgs e)
    {
    }
}