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
    public class LeaguesController : Controller
    {
        private LeagueContext db = new LeagueContext();

        //
        // GET: /Leagues/

        public ActionResult Index()
        {
            return View(db.Leagues.ToList());
        }

        //
        // GET: /Leagues/Details/5

        public ActionResult Details(string id = null)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // GET: /Leagues/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Leagues/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(League league)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Add(league);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(league);
        }

        //
        // GET: /Leagues/Edit/5

        public ActionResult Edit(string id = null)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // POST: /Leagues/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(League league)
        {
            if (ModelState.IsValid)
            {
                db.Entry(league).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(league);
        }

        //
        // GET: /Leagues/Delete/5

        public ActionResult Delete(string id = null)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // POST: /Leagues/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            League league = db.Leagues.Find(id);
            db.Leagues.Remove(league);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}