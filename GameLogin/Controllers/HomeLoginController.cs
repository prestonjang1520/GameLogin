using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLogin.Models;
using GameLogin.Models.Context;
using GameLogin.Models.GameLogin;

namespace GameLogin.Controllers
{
    public class HomeLoginController : Controller
    {

        private LeagueContext db = new LeagueContext();
        //variable to hold the password typed by the user so the user doesn't
        //have to retype it in
        static String loginPass = "";

        // GET: /HomeLogin/
        public ActionResult Index(string pass)
        {
            //This gets the emails of all the players in a string format
            //and puts it into the ViewBag
            ViewBag.AllEmails = getAllEmails();
            ViewBag.AllActiveEmails = getAllActiveEmails();

            List<Player> players = db.Players.ToList();
            List<Event> events = db.Events.ToList();

            if (pass != null)
            {
                loginPass = pass;
            }

            foreach(Event e in events)
            {
                if (loginPass.Equals(e.EventPassword))
                {

                    return View(new Tuple<List<Player>, Event>(players, e));
                }
            }

            return RedirectToAction("Index", "Home");
        }
        
        /*
        public ActionResult Index(string Login)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            for (int i = 0;
                 i < db.Players.ToList().Count;
                 ++i)
            {
                if (db.Players.ToList().ElementAt(i).Name == Login)
                {
                    db.Players.ToList().ElementAt(i).Active = true;
                }
            }

            db.SaveChanges();
            return View();
        }*/

        private string getAllEmails()
        {
            string mailingList = "mailto:";
            List<Player> players = db.Players.ToList();
            foreach (Player p in players)
            {
                mailingList += p.Email + "; ";
            }
            return mailingList;
        }

        //used to get all the active emails of all the players
        private string getAllActiveEmails()
        {
            string mailingList = "mailto:";
            List<Player> players = db.Players.ToList();
            foreach (Player p in players)
            {
                if (p.Active == true)
                {
                    mailingList += p.Email + "; ";
                }
                
            }
            return mailingList;
        }
    }
}
