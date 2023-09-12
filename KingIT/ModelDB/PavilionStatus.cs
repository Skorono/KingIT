using System.Collections.Generic;

namespace KingIT.ModelDB;

public class PavilionStatus : DataTransferEntity<char>
{
    public ICollection<Pavilion> Pavilions { get; set; } = new List<Pavilion>();
}