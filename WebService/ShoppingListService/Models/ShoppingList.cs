using System.Collections.Generic;
using System.Linq;

namespace ShoppingListService.Models
{
  public class ShoppingList
  {
    public IList<ShoppingListItem> Items { get; set; }

    public ShoppingList()
    {
      Items = new List<ShoppingListItem>();
    }
  }
}