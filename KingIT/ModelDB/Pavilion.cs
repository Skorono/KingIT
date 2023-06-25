namespace KingIT.ModelDB
{
    public class Pavilion
    {
        public int ID { get; set; }
        public string Number { get; set; } = null!;
        public int FloorNumber { get; set; }
        public float Square { get; set; }
        public int SquareMeterCost { get; set; }
        public float AddedCoefficient { get; set; }

        public PavilionStatus Status { get; set; } = null!;
        public ShoppingСenter ShoppingСenter { get; set; } = null!;
    }
}
