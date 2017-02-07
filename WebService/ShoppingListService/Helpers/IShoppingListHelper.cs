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
        /// A a new item to the list
        /// </summary>
        /// <param name="list">The shopping list</param>
        /// <param name="itemName">The item to add</param>
        /// <param name="quantity">The initial quantity for the item</param>
        /// <returns>null if successful. An Error if not successful.</returns>
        RequestError Add(ShoppingList list, string itemName, int quantity);

        /// <summary>
        /// Update an item that already exists in the list
        /// </summary>
        /// <param name="list">The shopping list</param>
        /// <param name="itemName">The item to update</param>
        /// <param name="quantity">The quantity to update</param>
        /// <returns>null if successful. An Error if not successful.</returns>
        RequestError Update(ShoppingList list, string itemName, int quantity);

        /// <summary>
        /// Delete an item that exists in the list
        /// </summary>
        /// <param name="list">The shopping list</param>
        /// <param name="itemName">The item to delete</param>
        /// <returns>null if successful. An Error if not successful.</returns>
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
