using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.IdentityModel.Tokens;
using ViewControls;
using WpfLibrary.Components.Forms;
using WpfLibrary.Tools;

namespace KingIT.Components;

public abstract class EntityCard : UserControl, IViewCard
{
    public int ID { get; set; }

    public Item ItemCard => _Card;
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
    
    protected void _SetNamedCardField(string FieldName, string? value)
    {
        var NameField = (TextBlock?)UIHelper.FindUid(_Card.Children, FieldName);
        if (NameField != null) NameField.Text = (string)value;
    }
    
    protected Item _Card;
}