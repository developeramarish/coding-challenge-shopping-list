namespace Checkout.ApiServices.ShoppingLists.ResponseModels
{
    /// <summary>
    /// The individual Shopping List Item object
    /// </summary>
    public class ShoppingListItem
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
    }
}