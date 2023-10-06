using System;
using System.Windows;

namespace KingIT;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Environment.SetEnvironmentVariable("ImagePath", "../../../../Assets/Images/");
        /*if (!BaseProvider.DbContext.Database.CanConnect())
            BaseProvider.DbContext.Database.Migrate();*/
        /*BaseProvider.DbContext.Database.EnsureDeleted();
        BaseProvider.DbContext.Database.EnsureCreated();*/
    }
}