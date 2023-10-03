using KingIT.Controls;
using Microsoft.EntityFrameworkCore;

namespace KingIT.Interfaces;

public abstract class Model
{
    public ModelManager<Model> _manager;

    public delegate void UpdatedDataDelegate(DbSet<Model> data);

    public abstract event UpdatedDataDelegate? Changed;
    public abstract void Update();
}