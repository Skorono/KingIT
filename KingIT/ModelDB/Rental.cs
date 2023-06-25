using System.ComponentModel.DataAnnotations;


namespace KingIT.ModelDB
{
    public class Rental
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;

        [Phone]
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
