﻿namespace KingIT.ModelDB;

public class ShoppingСenter
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public int Cost { get; set; }
    public float AddedCoefficient { get; set; }
    public int FloorsCount { get; set; }
    public string? Photo { get; set; }
    public int TownID { get; set; }
    public char StatusID { get; set; }


    public ShoppingCenterStatus Status { get; set; } = null!;
    public Town Town { get; set; } = null!;
}