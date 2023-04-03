using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final_project.Models;
namespace final_project.Controllers
{
    public class contactController : Controller
    {
        // GET: contact
        DBContext db = new DBContext();
        public ActionResult sendmess(contact n)
        {
            db.contacts.Add(n);
            db.SaveChanges();
            return RedirectToAction("contact","Home");
        }
    }
}