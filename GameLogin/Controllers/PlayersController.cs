using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLogin.Models;
using GameLogin.Models.Context;
using GameLogin.Models.GameLogin;

namespace GameLogin.Controllers
{
    public class PlayersController : Controller
    {
        private LeagueContext db = new LeagueContext();

        //
        // GET: /Players/

        public ActionResult Index()
        {
            return View(db.Players.ToList());
        }

        //
        // GET: /Players/Details/5

        public ActionResult Details(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // GET: /Players/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Players/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player player, string rosterName)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);

                List<Roster> rosters = db.Rosters.ToList();
                foreach (Roster r in rosters)
                {
                    if (r.RosterName.Equals(rosterName))
                    {
                        db.PlayerRosters.Add(new PlayerRoster
                        {
                            PlayerId = player.Id,
                            RosterId = r.RosterId
                        });
                        break;
                    }
                }

                /*foreach(Roster r in db.Rosters){
                    db.PlayerRosters.Add(new PlayerRoster{
                        PlayerId = player.Id,
                        RosterId = r.RosterId
                    });
                }*/
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        //
        // GET: /Players/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Players/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        //
        // GET: /Players/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Players/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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