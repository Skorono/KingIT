﻿namespace KingIT.Components;

public partial class ShoppingCenterCard : EntityCard
{
    public ShoppingCenterCard()
    {
        InitializeComponent();
        _Card = Card;
    }

    public override string? Name
    {
        set => _SetNamedCardField("ShoppingCenterName", value);
    }

    public int Cost
    {
        set => _SetNamedCardField("Cost", value.ToString());
    }

    public float AddedCoefficient
    {
        set => _SetNamedCardField("AddedCoefficient", value.ToString());

    }

    public int FloorsCount
    {
        set => _SetNamedCardField("FloorsCount", value.ToString());
    }
}