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
            List<Event> events = db.Events.ToList();

            if (pass != null)
            {
                loginPass = pass;
            }

            foreach(Event e in events)
            {
                if (loginPass.Equals(e.EventPassword))
                {
                    List<Player> eventPlayers = getPlayers(e.RosterId);

                    //This gets the emails of all the players in a string format
                    //and puts it into the ViewBag
                    ViewBag.AllEmails = getAllEmails(eventPlayers);
                    ViewBag.AllActiveEmails = getAllActiveEmails(eventPlayers);
                    ViewBag.AllInactiveEmails = getAllInactiveEmails(eventPlayers);
                    ViewBag.ManagerEmail = getManager(e.RosterId);

                    return View(new Tuple<List<Player>, Event>(eventPlayers, e));
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

        private string getAllEmails(List<Player> players)
        {
            string mailingList = "mailto:";
            foreach (Player p in players)
            {
                mailingList += p.Email + "; ";
            }
            return mailingList;
        }

        //gets the emails of all the active players
        private string getAllActiveEmails(List<Player> players)
        {
            string mailingList = "mailto:";
            foreach (Player p in players)
            {
                if (p.Active == true)
                {
                    mailingList += p.Email + "; ";
                }
                
            }
            return mailingList;
        }

        //gets the emails of all the inactive players
        private string getAllInactiveEmails(List<Player> players)
        {
            string mailingList = "mailto:";
            foreach (Player p in players)
            {
                if (p.Active == false)
                {
                    mailingList += p.Email + "; ";
                }

            }
            return mailingList;
        }

        private string getManager(int rosterId)
        {
            string leagueName = "";
            List<Event> events = db.Events.ToList();
            List<League> leagues = db.Leagues.ToList();
            foreach (Event e in events)
            {
                if (e.RosterId == rosterId)
                    leagueName = e.LeagueName;
            }

            foreach (League l in leagues)
            {
                if (l.LeagueName.Equals(leagueName))
                    return "mailto:" + l.Email;
            }

            return null;
        }

        //This method is used to find the correct players on the roster
        private List<Player> getPlayers(int rosterId)
        {
            List<PlayerRoster> PlayerRosters = db.PlayerRosters.ToList();
            List<Player> allPlayers = db.Players.ToList();
            List<Player> players = new List<Player>();
            foreach(PlayerRoster pr in PlayerRosters){
                if (pr.RosterId == rosterId)
                {
                    foreach (Player p in allPlayers)
                    {
                        if (p.Id == pr.PlayerId)
                            players.Add(p);
                    }
                }
            }
            return players;
        }
    }
}
