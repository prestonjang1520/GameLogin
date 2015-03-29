using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLogin.Models;
using System.Net.Mail;


namespace GameLogin.Controllers
{
    public class AutoEmailController : Controller
    {
        
        //
        // GET: /AutoEmail/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AutoEmail/Details/5


        //
        // GET: /AutoEmail/Create

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(GameLogin.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
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
                smtp.Send(mail);

                return View("AutoEmail", _objModelMail);
            }
            else
            {
                return View();
            }
        }
        /*
        public static void SendEmail(MailAddress fromAddress, MailAddress toAddress, string subject, string body)
        {
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            var client = new SmtpClient("gameLoginServer");
            //new UserMailer().Welcome().Send();
            client.Send(message);
        }*/

        //
        // POST: /AutoEmail/Create

      
        //
     
    }
}