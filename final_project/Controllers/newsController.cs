using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final_project.Models;
namespace final_project.Controllers
{
    public class newsController : Controller
    {
        // GET: news
        DBContext db = new DBContext();
        public ActionResult addnews()
        {
            if (Session["userid"] == null)
            {
               return RedirectToAction("login", "user");
            }
            SelectList cats = new SelectList(db.catalogs.ToList(),"id" ,"catname");
            ViewBag.cat = cats;
            return View();
        }

        [HttpPost]
        public ActionResult addnews(news n , HttpPostedFileBase img)
        {
            img.SaveAs(Server.MapPath($"~/attach/imgnews/{img.FileName}"));

            n.photo  = img.FileName;
            n.userid = (int)Session["userid"];
            n.newdate = DateTime.Now;
            db.news.Add(n);
            db.SaveChanges();
            return RedirectToAction("mynews");
        }

        public ActionResult mynews()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("login", "user");
            }
            int userid = (int)Session["userid"];
            List<news> nes = db.news.Where(n => n.userid == userid).ToList();

            return View(nes);
        }


        public ActionResult allnews()
        {
            List<news> ln = db.news.ToList();
            return View(ln);
        }

        public ActionResult details(int id)
        {
            news ns = db.news.Where(n => n.id == id).SingleOrDefault();

            return View(ns);
        }

        public ActionResult delete (int id)
        {
            news ns = db.news.Where(n => n.id == id).SingleOrDefault();
            db.news.Remove(ns);
            db.SaveChanges();
            return RedirectToAction("mynews");
        }

        public ActionResult edit(int id)
        {
            SelectList sl = new SelectList(db.catalogs.ToList(), "id", "catname");
            ViewBag.cat = sl;
            news ns = db.news.Where(n => n.id == id).SingleOrDefault();

            return View(ns);
        }
        [HttpPost]
        public ActionResult edit(news n , HttpPostedFileBase img)
        {
            img.SaveAs(Server.MapPath($"~/attach/imgnews/{img.FileName}"));
            n.photo = img.FileName;
            n.userid = (int)Session["userid"];
            n.newdate = DateTime.Now;
            db.Entry(n).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("mynews");
        }

    }

}