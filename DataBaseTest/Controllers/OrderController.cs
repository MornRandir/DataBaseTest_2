using System.Diagnostics;
using DataBaseTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Web;


//ProjectController

namespace DataBaseTest.Controllers
{
    public class OrderController : Controller
    {

        static readonly Dictionary<Guid, classOrder> updates = new Dictionary<Guid, classOrder>();

        [HttpPost]
        [ActionName("AddOrder")]
        public HttpResponseMessage PostComplex(classOrder update)
        {
            if (ModelState.IsValid && update != null)
            {
                // Convert any HTML markup in the status text.
                update.name = HttpUtility.HtmlEncode(update.name);

                // Assign a new ID.
                var id = Guid.NewGuid();
                updates[id] = update;

                // Create a 201 response.
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(update.name)
                };
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { action = "name", id = id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public classOrder name(Guid id)
        {
            classOrder update;
            if (updates.TryGetValue(id, out update))
            {
                return update;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }



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
