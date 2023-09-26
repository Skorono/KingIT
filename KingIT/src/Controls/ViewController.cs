using System.Windows.Controls;

namespace KingIT.Controls;

public class ViewController<T>
{
    public ViewController(T model)
    {
        Model = model;
    }

    protected T Model { get; set; }

    public void SetView(Control view)
    {
        foreach (var userP in typeof(T).GetProperties())
        {
            var property = view.GetType().GetProperty(userP.Name);
            if (property != null) property.SetValue(view, userP.GetValue(Model), null);
        }
    }
}