using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final_project.Models;

namespace final_project.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        DBContext db = new DBContext();
        public ActionResult AdminPage()
        {
            if(Session["useradmin"] ==null)
            {
                return RedirectToAction("login","user");

            }
            string admin = db.users.Where(n => n.username == "admin").Select(n=>n.username).SingleOrDefault();
            List<user> u = db.users.ToList();
            List<catalog> cat = db.catalogs.ToList();
            List<contact> con = db.contacts.ToList();
            ViewBag.cat = cat;
            ViewBag.admin = admin;
            ViewBag.con = con;
            return View(u);
        }
        public ActionResult delete(int id)
        {
            user user = db.users.Where(n => n.id == id).SingleOrDefault();
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("AdminPage");
        }

        public ActionResult addcat()
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("login", "user");
            }

            return View();
        }

        [HttpPost]
        public ActionResult addcat(catalog ca)
        {
            db.catalogs.Add(ca);
            db.SaveChanges();
            return RedirectToAction("AdminPage");
        }

        public ActionResult deletecat(int id)
        {
            catalog c = db.catalogs.Where(n => n.id == id).SingleOrDefault();
            db.catalogs.Remove(c);
            db.SaveChanges();
            return RedirectToAction("AdminPage");
        }

    }
}