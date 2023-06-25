using KingIT.ModelDB;

namespace KingIT
{
    public sealed class Administrator : Person
    {
        public Administrator(Employee model) : base(model)
        {
            Model.Role.ID = UserTypes.Administrator;
        }
    }
}
