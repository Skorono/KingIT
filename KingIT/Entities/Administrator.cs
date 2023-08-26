using KingIT.Controls;
using KingIT.Interfaces;

namespace KingIT.Views
{
    public sealed class Administrator: ViewController<IUser>
    {
        public Administrator(IUser model): base(model)
        {
            Model = model;
        }
    }
}
