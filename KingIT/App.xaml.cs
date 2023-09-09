using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace KingIT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() => BaseProvider.DbContext.Database.Migrate();
    }
}
