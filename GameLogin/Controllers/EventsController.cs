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
    public class EventsController : Controller
    {
        private LeagueContext db = new LeagueContext();

        //
        // GET: /Events/
        
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Roster).Include(e => e.League);
            return View(events.ToList());
        }
        
        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            Event TheEvent = db.Events.Find(id);
            if (TheEvent == null)
            {
                return HttpNotFound();
            }
            return View(TheEvent);
        }
        
        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            ViewBag.RosterId = new SelectList(db.Rosters, "RosterId", "RosterName");
            ViewBag.LeagueName = new SelectList(db.Leagues, "LeagueName", "TeamLogo");
            return View();
        }

        //
        // POST: /Events/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RosterId = new SelectList(db.Rosters, "RosterId", "RosterName", newEvent.RosterId);
            ViewBag.LeagueName = new SelectList(db.Leagues, "LeagueName", "TeamLogo", newEvent.LeagueName);
            return View(newEvent);
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event OldEvent = db.Events.Find(id);
            if (OldEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.RosterId = new SelectList(db.Rosters, "RosterId", "RosterName", OldEvent.RosterId);
            ViewBag.LeagueName = new SelectList(db.Leagues, "LeagueName", "TeamLogo", OldEvent.LeagueName);
            return View(OldEvent);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event OldEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(OldEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RosterId = new SelectList(db.Rosters, "RosterId", "RosterName", OldEvent.RosterId);
            ViewBag.LeagueName = new SelectList(db.Leagues, "LeagueName", "TeamLogo", OldEvent.LeagueName);
            return View(OldEvent);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event NewEvent = db.Events.Find(id);
            if (NewEvent == null)
            {
                return HttpNotFound();
            }
            return View(NewEvent);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event NewEvent = db.Events.Find(id);
            db.Events.Remove(NewEvent);
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