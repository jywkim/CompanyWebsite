﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyWebsite.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CompanyWebsite.Auth;
using CompanyWebsite.Helpers;

namespace CompanyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //CONTACT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailFormModel model)
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
                    AppHelper.SetFlash(MessageType.SUCCESS, "Thank you for your message!");
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            if (Request.UrlReferrer == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //LOGIN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using (CompanyWebsiteEntities db = new CompanyWebsiteEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == user.UserName && x.UserPass == user.UserPass).FirstOrDefault();
                if (userDetails == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.UserName;
                    Session["userFirstName"] = userDetails.UserFirstName;
                    AppHelper.SetFlash(MessageType.SUCCESS, "Hey " + userDetails.UserFirstName + "!");
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Logout()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}