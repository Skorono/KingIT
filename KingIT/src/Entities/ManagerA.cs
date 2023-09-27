using KingIT.Controls;
using KingIT.Interfaces;

namespace KingIT.Views;

public sealed class ManagerA : ViewController<IUser>
{
    public ManagerA(IUser user) : base(user)
    {
        Model = user;
    }
}