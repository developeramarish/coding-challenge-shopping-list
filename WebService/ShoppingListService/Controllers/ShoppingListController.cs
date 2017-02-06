using ShoppingListService.Helpers;
using ShoppingListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingListService.Controllers
{
  public class ShoppingListController : ApiController
  {
    IShoppingListHelper helper;

    //This is obviously a terrible idea but it's a simple in memory list (as per the brief)
    static ShoppingList shoppingList = new ShoppingList();

    public ShoppingListController(IShoppingListHelper shoppingListHelper)
    {
      helper = shoppingListHelper;
    }

    // GET: api/ShoppingList
    public ShoppingList Get()
    {
      return shoppingList;
    }

    // GET: api/ShoppingList/Pepsi
    public HttpResponseMessage Get(string itemName)
    {
      if (itemName == null) { return Request.CreateResponse(HttpStatusCode.BadRequest); }

      try
      {
        var item = helper.GetListItem(shoppingList, itemName);
        if (item == null)
        {
          return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        return Request.CreateResponse(item);
      }
      catch (Exception ex)
      {
        //To do log the exception somewhere
        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
      }
    }

    // POST: api/ShoppingList
    public HttpResponseMessage Post([FromBody]string itemName)
    {
      if (itemName == null) { return Request.CreateResponse(HttpStatusCode.BadRequest); }

      try
      {
        var error = helper.Add(shoppingList, itemName, 1);
        if (error != null)
        {
          return Request.CreateResponse(error.StatusCode, error.Message);
        }

        return Request.CreateResponse(HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        //To do log the exception somewhere
        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
      }
    }

    // PUT: api/ShoppingList/Pepsi
    public HttpResponseMessage Put(string itemName, [FromBody]int quantity)
    {
      if (itemName == null) { return Request.CreateResponse(HttpStatusCode.BadRequest); }

      try
      {
        var error = helper.Update(shoppingList, itemName, quantity);
        if (error != null)
        {
          return Request.CreateResponse(error.StatusCode, error.Message);
        }

        return Request.CreateResponse(HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        //To do log the exception somewhere
        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
      }
    }

    // DELETE: api/ShoppingList/Pepsi
    public HttpResponseMessage Delete(string itemName)
    {
      if (itemName == null) { return Request.CreateResponse(HttpStatusCode.BadRequest); }

      try
      {
        var error = helper.Delete(shoppingList, itemName);
        if (error != null)
        {
          return Request.CreateResponse(error.StatusCode, error.Message);
        }

        return Request.CreateResponse(HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        //To do log the exception somewhere
        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
      }
    }
  }
}
