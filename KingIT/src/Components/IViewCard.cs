using System.Windows;
using System.Windows.Media.Animation;
using WpfLibrary.Components.Forms;

namespace KingIT.Components;

public interface IViewCard : IInputElement, IAnimatable
{
    public int ID { get; set; }
    public Item ItemCard { get; }
}