using System.Collections.Generic;

namespace KingIT.ModelDB;

public class UserStatus : DataTransferEntity<char>
{
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}