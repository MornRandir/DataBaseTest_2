﻿using System.Diagnostics;
using DataBaseTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Http;

//ProjectController

namespace DataBaseTest.Controllers
{
    public class OrderController : Controller
    {





        public IActionResult Index()
        {
            using (var context = new OrderContext())
            {
                var order = new classOrder { id = 1, name = "test project name", tasks = "test description", email = "test@email.com" };
                context.Orders.Add(order);
                context.SaveChanges();

                return View();

            }

        }






        [HttpGet]
        public IActionResult All(int id)
        {
            using (var context = new OrderContext())
            {


                var orderlist = context.Orders.ToList();
                ViewBag.Fun = orderlist;

            }


            return View();
        }










    }
}




namespace FormEncode.Controllers
{
    using FormEncode.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;

    public class UpdatesController : ApiController
    {
        static readonly Dictionary<Guid, Update> updates = new Dictionary<Guid, Update>();

        [HttpPost]
        [ActionName("Complex")]
        public HttpResponseMessage PostComplex(Update update)
        {
            if (ModelState.IsValid && update != null)
            {
                // Convert any HTML markup in the status text.
                update.Status = HttpUtility.HtmlEncode(update.Status);

                // Assign a new ID.
                var id = Guid.NewGuid();
                updates[id] = update;

                // Create a 201 response.
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(update.Status)
                };
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public Update Status(Guid id)
        {
            Update update;
            if (updates.TryGetValue(id, out update))
            {
                return update;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}