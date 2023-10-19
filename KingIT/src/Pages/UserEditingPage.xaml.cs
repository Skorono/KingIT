using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KingIT.ModelDB;

namespace KingIT.Pages;

public partial class UserEditingPage : Page
{
    private Employee Model { get; set; }
    public UserEditingPage(Employee model)
    {
        InitializeComponent();
        Model = model;
        
        Name.Text = Model.Name;
        LastName.Text = Model.LastName;
        MiddleName.Text = Model.MiddleName;
        Login.Text = Model.Email;
        Password.Text = Model.Password;
        Roles.ItemsSource = BaseProvider.DbContext.Roles.Select(r => r.Name).ToList();
        //Roles.SelectedItem = Roles.Items.GetItemAt(Roles.ItemsSource.First(r => r == BaseProvider.DbContext.Roles.First(rl => rl.ID == Model.RoleID).ID));
        PhoneNumber.Text = Model.PhoneNumber;
    }

    private void Save(object sender, RoutedEventArgs e)
    {
        Model.Name  = Name.Text;
        Model.LastName = LastName.Text ;
        Model.MiddleName = MiddleName.Text;
        Model.Email = Login.Text;
        Model.Password= Password.Text;
        if (Roles.SelectedItem != null)    Model.RoleID = BaseProvider.DbContext.Roles.First(r => r.Name == Roles.SelectedItem.ToString()).ID;
        Model.PhoneNumber = PhoneNumber.Text;
        
        
        BaseProvider.DbContext.Employees.Update(Model);
        BaseProvider.DbContext.SaveChangesAsync();
        NavigationService.GoBack();
    }
}