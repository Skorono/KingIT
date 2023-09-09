using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Markup;

namespace KingIT.Components;

public partial class Capcha : UserControl, IDisposable
{
    private CapchaArgs Args = default!; 
    public class CapchaArgs
    {
        public VerticalAlignment Vertical = default;
        public HorizontalAlignment Horizontal = default;
        public int CulumnNumber;
        public int RowNumber;
        public int CapchaLength = 4;
        public IAddChild Layout;
    }
    public Capcha(CapchaArgs args)
    {
        InitializeComponent();
        Args = args;
    }

    private string GenerateCapchaText()
    {
        var random = new Random();
        const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Range(1, Args.CapchaLength).Select(
            _ => chars[random.Next(chars.Length)]
            ).ToArray());
    }
    public void Show()
    {
        this.HorizontalAlignment = Args.Horizontal;
        this.VerticalAlignment = Args.Vertical;
        Grid.SetColumn(this, Args.CulumnNumber);
        Grid.SetRow(this, Args.RowNumber);
        Args.Layout.AddChild(this);
    }

    public void Update()
    {
        ReCapchaText.Text = GenerateCapchaText();
        InputText.Text = default;
    }

    private void OnCapchaEnter(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (ReCapchaText.Text.Equals(InputText.Text.ToUpper().Trim()))
                Dispose();
            this.Update();
        }        
    }

   public void Dispose()
   {
       GC.SuppressFinalize(this);
       this.Visibility = Visibility.Collapsed;
   }

   private void OnGotFocus(object sender, RoutedEventArgs e)
   {
       Update();
   }
}