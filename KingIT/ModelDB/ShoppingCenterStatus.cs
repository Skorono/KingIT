using System.Collections.Generic;

namespace KingIT.ModelDB;

public class ShoppingCenterStatus : DataTransferEntity<char>
{
    public ICollection<ShoppingСenter> ShoppingCenters { get; set; } = new List<ShoppingСenter>();
}