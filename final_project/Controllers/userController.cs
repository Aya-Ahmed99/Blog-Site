using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final_project.Models;

namespace final_project.Controllers
{
    public class userController : Controller
    {
        // GET: user
        DBContext db = new DBContext();
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(user u , HttpPostedFileBase img)

        {
            //save imge in folder
            img.SaveAs(Server.MapPath("~/attach/" + img.FileName));
            u.photo = img.FileName;

            // check if user exist
            user d = db.users.Where(n => n.email == u.email).SingleOrDefault();
            if(d !=null)
            {
                ViewBag.satus = "E-mail aleardy exist !!";
                return View();
            }

            //add user to database
            if (ModelState.IsValid)
            {
                db.users.Add(u);
                db.SaveChanges();

                return RedirectToAction("login");
            }

            return View();
        }

        public ActionResult login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult login(user u)
        {
            user ud = db.users.Where(n => n.email == u.email && n.userpassword == u.userpassword).SingleOrDefault();
            
            if( ud !=null && ud.email == "admin@gmail.com")
            {
                Session.Add("useradmin", ud.id);
                return RedirectToAction("AdminPage","admin");

            }
            else if (ud != null )
            {
                Session.Add("userid", ud.id);
                return RedirectToAction("profile");
            }
            else
            {
                ViewBag.status = "Invalid Email / Password";
                return View();

            }

        }
        public ActionResult profile(user u)
        {

            if(Session["userid"] == null)
            {
                return RedirectToAction("login");

            }
            else
            {
                int id = (int)Session["userid"];
                user d = db.users.Where(n => n.id == id).SingleOrDefault();
                return View(d);
            }

        }

        public ActionResult logout()
        {
            Session["userid"] = null;
            Session["useradmin"] = null;
            return RedirectToAction("login");
        }

        public ActionResult editprofile(int id)
        {
            user u = db.users.Where(n => n.id == id).SingleOrDefault();

            return View(u);
        }

        [HttpPost]
        public ActionResult editprofile(user u , HttpPostedFileBase img)
        {
            img.SaveAs(Server.MapPath("~/attach/" + img.FileName));
            u.photo = img.FileName;

            u.id = (int)Session["userid"];
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("profile");
        }



    }
}