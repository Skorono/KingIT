using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace KingIT.Controls;

public abstract class EntityList: UserControl, ICardList
{
    public event Action CardClicked;

    protected CardFactory _listCardFactory { get; set; }
    
    public virtual void Update<T>(List<T> data)
    {
    }

    public virtual void OnCardDoubleClick(object sender, EventArgs e)
    {
        CardClicked.Invoke();
    }
}