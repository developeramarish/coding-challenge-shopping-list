using ShoppingListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ShoppingListService.Helpers
{
  public class ShoppingListHelper : IShoppingListHelper
  {
    /// <summary>
    /// A a new item to the list or increment the quantity of an existing item
    /// </summary>
    /// <param name="itemName">The item to add / update</param>
    /// <param name="quantity">The quantity for the item</param>
    public RequestError Add(ShoppingList list, string itemName, int quantity)
    {
      if (GetListItem(list, itemName) != null)
      {
        return new RequestError(HttpStatusCode.BadRequest, "Item already exists and cannot be added again. Please update the item instead");
      }

      list.Items.Add(new ShoppingListItem
      {
        Item = itemName,
        Quantity = quantity
      });

      return null;
    }

    public RequestError Update(ShoppingList list, string itemName, int quantity)
    {
      var listItem = GetListItem(list, itemName);
      if (listItem == null)
      {
        return new RequestError(HttpStatusCode.NotFound, "Item does not exist. Please add it first");
      }

      listItem.Quantity = quantity;

      return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="itemName"></param>
    /// <returns></returns>
    public RequestError Delete(ShoppingList list, string itemName)
    {
      var listItem = GetListItem(list, itemName);
      if (listItem == null)
      {
        return new RequestError(HttpStatusCode.NotFound, "Item does not exist. Please add it first");
      }

      list.Items.Remove(listItem);

      return null;
    }

    /// <summary>
    /// Get the existing list item from the list. 
    /// </summary>
    /// <param name="itemName">The name of the item to get</param>
    /// <returns>The list item if it exists. Otherwise null.</returns>
    public ShoppingListItem GetListItem(ShoppingList list, string itemName)
    {
      return list.Items.Where(items => items.Item.ToUpper() == itemName.ToUpper()).FirstOrDefault();
    }
  }
}