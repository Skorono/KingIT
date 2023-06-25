using Microsoft.EntityFrameworkCore;

namespace KingIT.ModelDB
{
    [Keyless]
    public class PavilionStaff
    {
        public Pavilion Pavilion { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
