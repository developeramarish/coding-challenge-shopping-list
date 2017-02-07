using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ShoppingListService.Models
{
    public class RequestError
    {
        public HttpStatusCode StatusCode { get; set; }

        public RequestError(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}