using System.Windows;

namespace KingIT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() => BaseProvider.DbContext.Database.EnsureCreated();
    }
}
