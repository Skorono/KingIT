using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.IdentityModel.Tokens;
using WpfLibrary.Components.Forms;
using WpfLibrary.Tools;

namespace KingIT.Components;

public abstract class EntityCard : UserControl, IViewCard
{
    protected Item _Card;

    public abstract string? Name { set; }

    public string? Photo
    {
        set
        {
            if (!value.IsNullOrEmpty())
                _Card.ItemImage =
                    ImageManager
                        .LoadImage(ImageManager.Upload(
                                Path.GetFullPath(
                                    Path.Combine(Environment.GetEnvironmentVariable("ImagePath"), value),
                                    Application.ResourceAssembly.Location)
                            )
                        );
        }
    }

    public Item ItemCard => _Card;
}