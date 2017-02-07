using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingListService;
using ShoppingListService.Controllers;
using ShoppingListService.Helpers;
using ShoppingListService.Models;
using System.Net;

namespace ShoppingListService.Tests.Controllers
{
    [TestClass]
    public class ShoppingListControllerTest
    {
        [TestMethod]
        public void GetEmptyList()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            ShoppingList result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Items.Count);
        }

        [TestMethod]
        public void GetByNameNotFound()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            HttpResponseMessage result = controller.Get("Pepsi");

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void PutNotFound()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            HttpResponseMessage result = controller.Put("Fanta", 2);

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void DeleteNotFound()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            HttpResponseMessage result = controller.Delete("Coca Cola");

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void PostSuccess()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            HttpResponseMessage result = controller.Post("Fanta");

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        [TestMethod]
        public void PostDuplicateFail()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            HttpResponseMessage result1 = controller.Post("7Up");
            HttpResponseMessage result2 = controller.Post("7Up");

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, result1.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, result2.StatusCode);
        }

        [TestMethod]
        public void PutSuccess()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            controller.Post("Lemonade");
            HttpResponseMessage result = controller.Put("Lemonade", 2);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void DeleteSuccess()
        {
            // Arrange
            var controller = new ShoppingListController(new ShoppingListHelper());
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            // Act
            controller.Post("Jack Daniels");
            HttpResponseMessage result = controller.Delete("Jack Daniels");

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}