using KingIT.Interfaces;
using KingIT.ModelDB;
using Microsoft.EntityFrameworkCore;

namespace KingIT.Controls;

public class ModelManager<T> where T: Model
{
    private T _model;
    
    public ModelManager(T model)
    {
        _model = model;
        //_model.Changed += SaveChanges;
    }

    public ModelManager()
    {
    }

    private void SaveChanges(DbSet<Employee> db)
    {
        
    }
}