using System.Windows;

namespace KingIT;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        BaseProvider.DbContext.SaveChanges();
        /*if (!BaseProvider.DbContext.Database.CanConnect())
            BaseProvider.DbContext.Database.Migrate();*/
        /*BaseProvider.DbContext.Database.EnsureDeleted();
        BaseProvider.DbContext.Database.EnsureCreated();*/
    }
}