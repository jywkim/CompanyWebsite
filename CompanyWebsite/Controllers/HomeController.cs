using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your portfolio page.";

            return View();
        }

        public ActionResult Clients()
        {
            ViewBag.Message = "Your clients page.";

            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Your products page.";

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Job()
        {
            return View();
        }
    }
}