using System.Windows;
using System.Windows.Media.Animation;
using WpfLibrary.Components.Forms;

namespace KingIT.Components;

public interface IViewCard : IInputElement, IAnimatable
{
    public Item ItemCard { get; }
}