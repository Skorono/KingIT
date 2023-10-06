namespace KingIT.ModelDB;

public class PavilionStaff
{
    public int PavilionID { get; set; }

    public int EmployeeID { get; set; }
    
    public Pavilion Pavilion { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}