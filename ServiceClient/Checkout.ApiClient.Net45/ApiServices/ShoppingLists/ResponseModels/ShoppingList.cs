using System.Collections.Generic;

namespace Checkout.ApiServices.ShoppingLists.ResponseModels
{
    /// <summary>
    /// The overall Shopping List object
    /// </summary>
    public class ShoppingList
    {
        public IList<ShoppingListItem> Items { get; set; }
    }
}