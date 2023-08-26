using KingIT.Views;
using KingIT.Interfaces;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace KingIT.Controls
{
    public class ViewController<T>
    {
        protected T Model { get; set; }

        public ViewController(T model) {
            Model = model;
        }

        public void SetView<K>(K view) where K : Control
        {
            foreach (var userP in typeof(T).GetProperties())
            {
                var property = view.GetType().GetProperty(userP.Name);
                if (property != null)
                {
                    property.SetValue(view, userP.GetValue(Model), null);
                }
            }
        }
    }
}
