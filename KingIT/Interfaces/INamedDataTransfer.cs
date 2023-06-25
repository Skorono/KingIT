namespace KingIT.Interfaces
{
    public interface INamedDataTransfer<T>
    {
        T ID { get; set; }
        string Name { get; set; }
    }
}
