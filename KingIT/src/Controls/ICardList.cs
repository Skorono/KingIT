using System.Collections.Generic;

namespace KingIT.Controls;

public interface ICardList
{
    public void Update<T>(List<T> data);
}