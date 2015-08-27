using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLogin.Models.GameLogin;
using GameLogin.Models.Context;
using System.Net.Mail;


using Quartz;
using Quartz.Impl;
using Quartz.Job;
using Quartz.Impl.Triggers;
namespace GameLogin.Controllers
{
    public class AdminsController : Controller
    {
        static String userInput;

        public static string mailTo { get; set; }
        public static string mailSubject { get; set; }
        public static string mailBody  { get; set; }
        public static int daysBefore { get; set; }

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

        /*
         * Method used to get the Notices page
         * 
         * Returns: the Notices page
         * */
        public ActionResult Notices()
        {
            return View();
        }

        /*
         * Method used to get the Roster page
         * 
         * Returns: the Roster page
         * */
        public ActionResult Roster()
        {
            return View();
        }

        /*
         * Method used to get the Reset page
         * 
         * Returns: the Reset page
         * */
        public ActionResult Reset()
        {
            return View();
        }

        /*
         * method used to get the Admin home page. Function will check the user input to the league 
         * name and its admin password. If correct, the browser will be directed to the proper league
         * admin page. If incorrect, will simply go back to the league home page.
         * 
         * Returns: Page depending on if password is correct 
         * */
        public ActionResult Home(string leagueName, string adminpass)
        {
            if (adminpass == null)
                return RedirectToAction("Index", "HomeLogin");

            userInput = adminpass;
            Admin admin = null;
            List<Admin> admins = db.Admins.ToList();

            foreach (Admin a in admins)
            {
                if (userInput.Equals(a.Password))
                    admin = a;
            }

            if (admin == null)
                return RedirectToAction("Index", "HomeLogin");

            if (leagueName.Equals(admin.LeagueName))
                return View(admin);

            return RedirectToAction("Index", "HomeLogin");
        }

        /*
         * Method used to get the Game Day page
         * 
         * Returns: the Game Day page
         * */
        public ActionResult GameDay()
        {
            return View();
        }

        /*
         * Method used to get the System page
         * 
         * Returns: the System page
         * */
        public ActionResult System()
        {
            return View();
        }

        /*
         * Method used to get the Auto Email page
         * 
         * Returns: the Auto Email page
         * */
        public ActionResult AutoEmail()
        {
            return View();
        }

        /*
         * Method to send emails to all subscribers
         * */
        [HttpPost]
        public ActionResult SendEmail(GameLogin.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                /*
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                //mail.From = new MailAddress(_objModelMail.From);
                mail.From = new MailAddress("gameloginbcit@gmail.com");
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587; //25 is local 587 is normal
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("gameloginbcit@gmail.com", "comp3900");// Enter senders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);*/

                mailTo = _objModelMail.To;
                mailSubject = _objModelMail.Subject;
                mailBody = _objModelMail.Body;

                LeagueContext maildb = new LeagueContext();
                List<GameLogin.Models.GameLogin.Event> eventdb = maildb.Events.ToList();

                DateTime gameDate = eventdb[0].EventDate;
                foreach (GameLogin.Models.GameLogin.Event d in eventdb)
                {
                    if (gameDate > d.EventDate)
                    {
                        gameDate = d.EventDate;
                    }
                }


                int month = gameDate.Month;
                //int month = DateTime.Now.Month;
                int day = gameDate.Day;
                if (gameDate.Day - _objModelMail.daysBefore < 0)
                {
                    month = month - 1;

                    int temp = Math.Abs(gameDate.Day - _objModelMail.daysBefore);

                    if (DateTime.Now.Month == 1)
                    {
                        day = 31 - temp;
                    }
                    else if (DateTime.Now.Month == 2)
                    {
                        day = 28 - temp;
                        //day = 30;
                    }
                    else if (DateTime.Now.Month == 3)
                    {
                        day = 31 - temp;
                        //day = 30;
                    }
                    else if (DateTime.Now.Month == 4)
                    {
                        day = 30 - temp;
                    }
                    else if (DateTime.Now.Month == 5)
                    {
                        day = 31 - temp;
                    }
                    else if (DateTime.Now.Month == 6)
                    {
                        day = 30 - temp;
                    }
                    else if (DateTime.Now.Month == 7)
                    {
                        day = 31 - temp;
                    }
                    else if (DateTime.Now.Month == 8)
                    {
                        day = 31 - temp;
                    }
                    else if (DateTime.Now.Month == 9)
                    {
                        day = 30 - temp;
                    }
                    else if (DateTime.Now.Month == 10)
                    {
                        day = 31 - temp;
                    }
                    else if (DateTime.Now.Month == 11)
                    {
                        day = 30 - temp;
                    }
                    else
                    {
                        day = 31 - temp;
                    }

                }
                else
                {
                    day = gameDate.Day - _objModelMail.daysBefore;
                    //day = 30;
                }




                //hours, minutes, seconds, day, month
                DateTimeOffset startTime = DateBuilder.DateOf(16, 30, 0, day, month);


                ISchedulerFactory schedFact = new StdSchedulerFactory();
                IScheduler sched = schedFact.GetScheduler();
                sched.Start();
                IJobDetail jobDetail = JobBuilder.Create<GameLoginEmailClass>().Build();

                //ITrigger trigger = TriggerBuilder.Create().WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0, 28)).Build();
                ISimpleTrigger trigger2 = (ISimpleTrigger)TriggerBuilder.Create().StartAt(startTime).Build();
                sched.ScheduleJob(jobDetail, trigger2);

                return View("AutoEmail", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}