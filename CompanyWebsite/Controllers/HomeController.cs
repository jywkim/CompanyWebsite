using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyWebsite.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CompanyWebsite.Auth;

namespace CompanyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Careers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("test@reainc.net"));
                message.From = new MailAddress(model.FromEmail);
                message.Subject = "Contact Form Email";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    CredentialContext credentialContext = new CredentialContext();

                    var credential = new NetworkCredential
                    {
                        UserName = credentialContext.Mailtrap_Username,
                        Password = credentialContext.Mailtrap_Password
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.mailtrap.io";
                    smtp.Port = 2525;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}