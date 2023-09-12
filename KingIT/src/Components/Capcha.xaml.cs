using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace KingIT.Components;

public partial class Capcha : UserControl, IDisposable
{
    private readonly CapchaArgs Args = default!;

    public Capcha(CapchaArgs args)
    {
        InitializeComponent();
        Args = args;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Visibility = Visibility.Collapsed;
    }

    private string GenerateCapchaText()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Range(1, Args.CapchaLength).Select(
            _ => chars[random.Next(chars.Length)]
        ).ToArray());
    }

    public void Show()
    {
        HorizontalAlignment = Args.Horizontal;
        VerticalAlignment = Args.Vertical;
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
            Update();
        }
    }

    private void OnGotFocus(object sender, RoutedEventArgs e)
    {
        Update();
    }

    public class CapchaArgs
    {
        public int CapchaLength = 4;
        public int CulumnNumber;
        public HorizontalAlignment Horizontal = default;
        public IAddChild Layout;
        public int RowNumber;
        public VerticalAlignment Vertical = default;
    }
}