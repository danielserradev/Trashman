using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProgram.Models;

namespace TrashCollectorProgram.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index(int zipcode)
        {
            if (User.IsInRole("Employee"))
            {
                //Employee emploeyy = context.Employees.Where(e => e.zipcode == zipcode).FirstOrDefault();
                return RedirectToAction("GetPickups", "Employees", zipcode);
            }
            else if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Customers");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}