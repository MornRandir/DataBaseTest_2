using System.Diagnostics;
using DataBaseTest.Models;
using Microsoft.AspNetCore.Mvc;
using DataBaseTest.Models;

namespace DataBaseTest.Controllers
{
    public class AddProject : Controller
    {
        public ActionResult Index()
        {
            classAddProject[] m_info = {
                new classAddProject { id = 1, name = "test project name", description = "test description", email = "test@email.com"},
                new classAddProject { id = 2, name = "test project name", description = "test description", email = "test@email.com"},
                new classAddProject { id = 3, name = "test project name", description = "test description", email = "test@email.com"}
            };

            ViewBag.Fun = m_info;

            return View();
        }

        [HttpGet]
        public IActionResult Add(int id)
        {

            ViewBag.t = "test";
            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {

            ViewBag.t = "test";
            return View();
        }




    }
}
