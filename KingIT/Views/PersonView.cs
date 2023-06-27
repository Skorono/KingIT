using KingIT.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingIT.Views
{
    public class PersonView
    {
        public Employee Model { get; private set; }

        public string Name => Model.Name;

        public string? LastName => Model.LastName;

        public string? MiddleName => Model.MiddleName;

        public string? PhoneNumber => Model.PhoneNumber;

        public string? Email => Model.Email;

        public char Role => Model.Role.ID;

        public byte[]? Photo => Model.Photo;

        public PersonView(Employee model)
        {
            Model = model;
        }
    }
}
