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
        /// A a new item to the list
        /// </summary>
        /// <param name="list">The shopping list</param>
        /// <param name="itemName">The item to add</param>
        /// <param name="quantity">The initial quantity for the item</param>
        /// <returns>null if successful. An Error if not successful.</returns>
        public RequestError Add(ShoppingList list, string itemName, int quantity)
        {
            if (GetListItem(list, itemName) != null)
            {
                return new RequestError(HttpStatusCode.BadRequest);
            }

            list.Items.Add(new ShoppingListItem
            {
                Item = itemName,
                Quantity = quantity
            });

            return null;
        }

        /// <summary>
        /// Update an item that already exists in the list
        /// </summary>
        /// <param name="list">The shopping list</param>
        /// <param name="itemName">The item to update</param>
        /// <param name="quantity">The quantity to update</param>
        /// <returns>null if successful. An Error if not successful.</returns>
        public RequestError Update(ShoppingList list, string itemName, int quantity)
        {
            var listItem = GetListItem(list, itemName);
            if (listItem == null)
            {
                return new RequestError(HttpStatusCode.NotFound);
            }

            listItem.Quantity = quantity;

            return null;
        }

        /// <summary>
        /// Delete an item that exists in the list
        /// </summary>
        /// <param name="list">The shopping list</param>
        /// <param name="itemName">The item to delete</param>
        /// <returns>null if successful. An Error if not successful.</returns>
        public RequestError Delete(ShoppingList list, string itemName)
        {
            var listItem = GetListItem(list, itemName);
            if (listItem == null)
            {
                return new RequestError(HttpStatusCode.NotFound);
            }

            list.Items.Remove(listItem);

            return null;
        }

        /// <summary>
        /// Get the existing list item from the list. 
        /// </summary>
        /// <param name="itemName">The name of the item to get</param>
        /// <param name="list">The shopping list</param>
        /// <returns>The list item if it exists. Otherwise null.</returns>
        public ShoppingListItem GetListItem(ShoppingList list, string itemName)
        {
            return list.Items.Where(items => items.Item.ToUpper() == itemName.ToUpper()).FirstOrDefault();
        }
    }
}