using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingListService.Helpers;
using ShoppingListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListService.Tests.Helpers
{
    [TestClass]
    public class ShoppingListHelperTests
    {
        IShoppingListHelper helper = new ShoppingListHelper();

        [TestMethod]
        public void TestAdd()
        {
            var list = new ShoppingList();
            helper.Add(list, "Fanta", 2);

            Assert.AreEqual(1, list.Items.Count);
            Assert.AreEqual("Fanta", list.Items[0].Item);
            Assert.AreEqual(2, list.Items[0].Quantity);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var list = new ShoppingList();
            helper.Add(list, "Fanta", 2);
            helper.Update(list, "Fanta", 10);

            Assert.AreEqual(1, list.Items.Count);
            Assert.AreEqual("Fanta", list.Items[0].Item);
            Assert.AreEqual(10, list.Items[0].Quantity);
        }

        [TestMethod]
        public void TestDelete()
        {
            var list = new ShoppingList();
            list.Items.Add(new ShoppingListItem { Item = "Coca Cola", Quantity = 5 });

            helper.Delete(list, "Coca Cola");

            Assert.AreEqual(0, list.Items.Count);
        }

        [TestMethod]
        public void TestGetListItem()
        {
            var list = new ShoppingList();
            list.Items.Add(new ShoppingListItem { Item = "7Up", Quantity = 5 });

            var item = helper.GetListItem(list, "7Up");

            Assert.AreEqual(1, list.Items.Count);
            Assert.AreEqual("7Up", item.Item);
            Assert.AreEqual(5, item.Quantity);
        }
    }
}
