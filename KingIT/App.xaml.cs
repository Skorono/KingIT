using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace KingIT;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        if (!BaseProvider.DbContext.Database.CanConnect())
            BaseProvider.DbContext.Database.Migrate();
    }
}