using KingIT.ModelDB;

namespace KingIT.Views
{
    public sealed class Administrator : PersonView
    {
        public Administrator(Employee model) : base(model)
        {
            Model.Role.ID = UserTypes.Administrator;
        }
    }
}
