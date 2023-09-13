using WpfLibrary.Components.Forms;

namespace KingIT.Components;

public interface IViewCard: System.Windows.IInputElement,  System.Windows.Media.Animation.IAnimatable
{
    public Item ItemCard { get; }
}