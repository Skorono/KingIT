using KingIT.ModelDB;

namespace KingIT.Views
{
    public sealed class User : PersonView
    {
        public User(Employee model) : base(model)
        {
            Model.Role.ID = UserTypes.User;
        }
    }
}


