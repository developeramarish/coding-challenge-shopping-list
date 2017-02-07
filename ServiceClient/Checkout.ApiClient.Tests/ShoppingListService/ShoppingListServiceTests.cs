using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListServiceTests : BaseServiceTests
    {
        [Test]
        public void GetShoppingList()
        {
            CheckoutClient.ShoppingListService.AddShoppingListItem("Ginger Beer");
            var response = CheckoutClient.ShoppingListService.GetShoppingList();

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Items.Count.Should().BeGreaterThan(0);// Can't reliably get a count right now becuse of the static list in the service
        }

        [Test]
        public void GetNonExistantShoppingListItem()
        {
            var response = CheckoutClient.ShoppingListService.GetShoppingListItem("Fanta");

            response.Should().BeNull();
        }

        [Test]
        public void UpdateNonExistantShoppingListItem()
        {
            var response = CheckoutClient.ShoppingListService.UpdateShoppingListItem("Fanta", 2);

            response.Should().BeNull();
        }

        [Test]
        public void DeleteNonExistantShoppingListItem()
        {
            var response = CheckoutClient.ShoppingListService.DeleteShoppingListItem("Fanta");

            response.Should().BeNull();
        }

        [Test]
        public void ShoppingListItemAdd()
        {
            var itemName = "Lemonade";
            var response = CheckoutClient.ShoppingListService.AddShoppingListItem(itemName);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.Created);
            response.Model.Item.Should().Be(itemName);
            response.Model.Quantity.Should().Be(1);
        }

        [Test]
        public void ShoppingListItemAddDuplicateFail()
        {
            CheckoutClient.ShoppingListService.AddShoppingListItem("Pepsi");
            var response = CheckoutClient.ShoppingListService.AddShoppingListItem("Pepsi");

            response.Should().BeNull();
        }

        [Test]
        public void UpdateShoppingListItem()
        {
            var itemName = "Coca Cola";
            CheckoutClient.ShoppingListService.AddShoppingListItem(itemName);
            var response = CheckoutClient.ShoppingListService.UpdateShoppingListItem(itemName, 20);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Item.Should().Be(itemName);
            response.Model.Quantity.Should().Be(20);
        }

        [Test]
        public void DeleteShoppingListItem()
        {
            CheckoutClient.ShoppingListService.AddShoppingListItem("7Up");
            var response = CheckoutClient.ShoppingListService.DeleteShoppingListItem("7Up");

            response.Should().BeNull();
        }
    }
}
