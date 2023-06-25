using KingIT.Interfaces;

namespace KingIT
{
    public abstract class DataTransferEntity<T> : INamedDataTransfer<T>
    {
        public T ID { get; set; }
        public string Name { get; set; } = null!;
    }
}
