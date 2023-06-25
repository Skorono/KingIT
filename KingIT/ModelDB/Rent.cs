using System;

namespace KingIT.ModelDB
{
    public class Rent
    {
        public int RentID { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }

        public Rental Rental { get; set; } = null!;
        public Pavilion Pavilion { get; set; } = null!;
    }
}
