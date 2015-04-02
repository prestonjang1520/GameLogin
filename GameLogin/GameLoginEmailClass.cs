using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net.Mail;
using GameLogin.Models.GameLogin;
using GameLogin.Models.Context;
using GameLogin.Models;
using GameLogin.Controllers;

namespace GameLogin
{
    public class GameLoginEmailClass : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            SendMail();
        }

        public void SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(AdminsController.mailTo);
            mail.From = new MailAddress("gameloginbcit@gmail.com");
            mail.Subject = AdminsController.mailSubject;
            string Body = AdminsController.mailBody;
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
        }
    }
}