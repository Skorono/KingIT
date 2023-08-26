using KingIT.Controls;
using KingIT.Interfaces;

namespace KingIT.Views
{
    public sealed class User : ViewController<IUser>
    {
        public User(IUser user): base(user)
        {
            Model = user;
        }
    }
}


