using KingIT.ModelDB;

namespace KingIT
{
    public sealed class User : Person
    {
        public User(Employee model) : base(model)
        {
            Model.Role.ID = UserTypes.User;
        }
    }
}
