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
    public class RostersController : Controller
    {
        private LeagueContext db = new LeagueContext();

        //
        // GET: /Rosters/

        public ActionResult Index()
        {
            return View(db.Rosters.ToList());
        }

        //
        // GET: /Rosters/Details/5

        public ActionResult Details(int id = 0)
        {
            Roster roster = db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        //
        // GET: /Rosters/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rosters/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Roster roster)
        {
            if (ModelState.IsValid)
            {
                db.Rosters.Add(roster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roster);
        }

        //
        // GET: /Rosters/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Roster roster = db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        //
        // POST: /Rosters/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Roster roster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roster);
        }

        //
        // GET: /Rosters/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Roster roster = db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        //
        // POST: /Rosters/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roster roster = db.Rosters.Find(id);
            db.Rosters.Remove(roster);
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