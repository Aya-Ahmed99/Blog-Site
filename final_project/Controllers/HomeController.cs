using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final_project.Models;

namespace final_project.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            List<news> ln = db.news.ToList();
            return View(ln);
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