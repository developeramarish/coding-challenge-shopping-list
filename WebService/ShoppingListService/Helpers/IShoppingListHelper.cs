using ShoppingListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListService.Helpers
{
  public interface IShoppingListHelper
  {
    /// <summary>
    /// A a new item to the list or increment the quantity of an existing item
    /// </summary>
    /// <param name="itemName">The item to add / update</param>
    /// <param name="quantity">The quantity for the item</param>
    /// <param name="list">The shopping list</param>
    RequestError Add(ShoppingList list, string itemName, int quantity);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="itemName"></param>
    /// <param name="quantity"></param>
    /// <param name="list">The shopping list</param>
    /// <returns></returns>
    RequestError Update(ShoppingList list, string itemName, int quantity);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="itemName"></param>
    /// <returns></returns>
    RequestError Delete(ShoppingList list, string itemName);

    /// <summary>
    /// Get the existing list item from the list. 
    /// </summary>
    /// <param name="itemName">The name of the item to get</param>
    /// <param name="list">The shopping list</param>
    /// <returns>The list item if it exists. Otherwise null.</returns>
    ShoppingListItem GetListItem(ShoppingList list, string itemName);
  }
}
