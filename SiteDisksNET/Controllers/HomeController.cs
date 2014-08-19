using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteDisksNET.Models;
using System.Net;
using System.Net.Mail;

namespace SiteDisksNET.Controllers
{
    public class HomeController : Controller
    {
        private lowataEntities _DB = new lowataEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "SiteDisks always provides the fast, unique, reliable services acrossing website design & build, SEO, online marketing and so on.";

            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "We creating real relationships, asking real questions, and participate in more than just projects.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We always reachable in anytime, and be thankful and show appreciation.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                //Store DB
                _DB.Contacts.Add(model);
                _DB.SaveChanges();

                //Send email
                MailMessage mailMsg = new MailMessage();
                NetworkCredential userinfo = new NetworkCredential();
                mailMsg.From = new MailAddress(model.Email);
                mailMsg.To.Add("info@sitedisks.com.au");
                mailMsg.Subject = model.Subject;
                mailMsg.Body = "Message: " + model.Message + "\n\nFrom: " + model.Name;

                SmtpClient smtp = new SmtpClient("mail.lowata.com.au");
                userinfo = new NetworkCredential("postmaster@lowata.com.au", "@@Xpand42");
                smtp.Credentials = userinfo;

                try
                {
                    smtp.Send(mailMsg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    mailMsg = null;
                    smtp = null;
                }

                return PartialView("_ThankYou");
            }
            ModelState.AddModelError("Contact", "One or more contact errors were found");
          
            return PartialView("_ContactForm", model);
        }


     
    }
}
