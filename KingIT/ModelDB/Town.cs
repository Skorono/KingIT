using System.ComponentModel.DataAnnotations;

namespace KingIT.ModelDB;

public class Town
{
    [Key] public int ID { get; set; }

    public string Name { get; set; } = null!;
}