using System.Collections.Generic;

namespace KingIT.ModelDB;

public class Role : DataTransferEntity<char>
{
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}