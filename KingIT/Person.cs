using KingIT.ModelDB;

namespace KingIT
{
    public class Person
    {
        protected Employee Model;

        public char Role => Model.Role.ID;

        protected Person(Employee model)
        {
            Model = model;
        }
    }
}
