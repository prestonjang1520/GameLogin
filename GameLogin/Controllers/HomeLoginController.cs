using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLogin.Models;
using GameLogin.Models.Context;

namespace GameLogin.Controllers
{
    public class HomeLoginController : Controller
    {

        private LeagueContext db = new LeagueContext();
        //
        // GET: /HomeLogin/
        static String loginPass = "";
        public ActionResult Index(string pass)
        {
            if (pass != null)
            {
                loginPass = pass;
            }
            if (loginPass.Equals("bcit"))
            {
                return View(new
                    Tuple<List<GameLogin.Models.Player>,
                            List<GameLogin.Models.GameLogin.Event>
                         >(db.Players.ToList(), db.Events.ToList()));
            }
            else
                return RedirectToAction("Index", "Home");
        }/*
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
    }
}
