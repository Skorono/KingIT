using System.Collections.Generic;
using System.Windows;
using KingIT.Components;

namespace KingIT.Controls;

public partial class PavilionList : EntityList
{
    public PavilionCard CardView
    {
        set => _listCardFactory.SetCardView(value);
    }
    
    public int ShoppingCenterID { private set; get; }

    public PavilionList(int id)
    {
        InitializeComponent();
        _listCardFactory = new PavilionCardFactory();
        CardView = new PavilionCard();
        _listCardFactory.SetDoubleClickEvent(OnCardDoubleClick);
        ShoppingCenterID = id;
    }


    public override void Update<T>(List<T> data)
    {
        Area.Clear();
        data.ForEach(d => Area.Add(_listCardFactory.Make(d) as UIElement));
    }

    /*public override void OnCardDoubleClick(object sender, EventArgs e)
    {
        CardClicked.Invoke();
    }*/
}