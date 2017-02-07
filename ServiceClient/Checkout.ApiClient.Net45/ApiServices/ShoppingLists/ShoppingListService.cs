using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingLists.ResponseModels;

namespace Checkout.ApiServices.ShoppingLists
{
    public class ShoppingListService
    {
        /// <summary>
        /// Return the full list of items on the shopping list
        /// </summary>
        /// <returns></returns>
        public HttpResponse<ShoppingList> GetShoppingList()
        {
            return new ApiHttpClient().GetRequest<ShoppingList>(ApiUrls.ShoppingList, AppSettings.SecretKey);
        }

        /// <summary>
        /// Return an item and it's quantity from the shopping list
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public HttpResponse<ShoppingListItem> GetShoppingListItem(string itemName)
        {
            var getShoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, itemName);
            return new ApiHttpClient().GetRequest<ShoppingListItem>(getShoppingListItemUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Add a new item to the shopping list
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public HttpResponse<ShoppingListItem> AddShoppingListItem(string itemName)
        {
            var addShoppingListItemUri = ApiUrls.ShoppingListItem;
            return new ApiHttpClient().PostRequest<ShoppingListItem>(addShoppingListItemUri, AppSettings.SecretKey, itemName);
        }

        /// <summary>
        /// Update the quantity of an existing item on the shopping list
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public HttpResponse<ShoppingListItem> UpdateShoppingListItem(string itemName, int quantity)
        {
            var updateShoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, itemName);
            return new ApiHttpClient().PutRequest<ShoppingListItem>(updateShoppingListItemUri, AppSettings.SecretKey, quantity);
        }

        /// <summary>
        /// Delete an item from the shopping list
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> DeleteShoppingListItem(string itemName)
        {
            var deleteShoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, itemName);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteShoppingListItemUri, AppSettings.SecretKey);
        }
    }
}
