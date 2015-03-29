using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLogin.Models.GameLogin;
using GameLogin.Models.Context;

namespace GameLogin.Controllers
{
    public class AdminsController : Controller
    {
        private LeagueContext db = new LeagueContext();

        //
        // GET: /Admins/

        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        //
        // GET: /Admins/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admins/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admins/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admins/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admins/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admins/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admins/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Notices()
        {
            return View();
        }

        public ActionResult Roster()
        {
            return View();
        }

        public ActionResult Reset()
        {
            return View();
        }

        static String userInput;
        public ActionResult Home(string adminpass)
        {
            if (adminpass != null)
            {
                userInput = adminpass;
            }
            if (userInput.Equals("ticb"))
                return View();
            else
                return RedirectToAction("Index", "HomeLogin");;
        }

        public ActionResult GameDay()
        {
            return View();
        }

        public ActionResult System()
        {
            return View();
        }

        public ActionResult AutoEmail()
        {
            return View();
        }
    }
}