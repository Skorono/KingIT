﻿using System.IO;
using System.Windows.Controls;
using WpfLibrary.Components.Forms;
using WpfLibrary.Tools;

namespace KingIT.Components;

/// <summary>
///     Логика взаимодействия для PavilionCard.xaml
/// </summary>
public partial class PavilionCard : UserControl, IViewCard
{
    public PavilionCard()
    {
        InitializeComponent();
    }

    public int ID { get; set; }
    public string Photo
    {
        set => Card.ItemImage = ImageManager.LoadImage(ImageManager.Upload(Path.GetFullPath(value)));
    }

    public int FloorNumber { get; set; }
    public string Number { get; set; } = null!;
    public string StatusName { get; set; } = null!;
    public float Square { get; set; }
    public float AddedCoefficient { get; set; }
    public int Cost { get; set; }
    
    public Item ItemCard => Card; 
    private void SetProperty(string property)
    {
    }
}