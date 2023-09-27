using KingIT.Controls;
using KingIT.Interfaces;

namespace KingIT.Views;

public class ManagerC: ViewController<IUser>
{
    public ManagerC(IUser model) : base(model)
    {
        Model = model;
    }
}