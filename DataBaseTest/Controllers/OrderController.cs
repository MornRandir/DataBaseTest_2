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




        [HttpPost]
        public IActionResult Index(string name, string tasks, string email)
        {
            string addProjectData = $"Name: {name}  Tasks: {tasks} Email: {email}";
            return Content(addProjectData);
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
