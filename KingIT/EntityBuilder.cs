namespace KingIT;

/*public static class EntityBuilder
{
    public static List<Entity>? GetData<Entity>(Type DataSourceT) where Entity : DataTransferEntity<object>, new()
    {
        
        List<Entity> Data = new List<Entity>();
        foreach (var roleField in DataSourceT.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            Data.Add(new Entity { ID = (char)roleField.GetValue(DataSourceT)!, Name = roleField.Name });
        }

        return Data;
    }
}*/