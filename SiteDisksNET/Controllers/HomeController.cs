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
        private IRepository<Portfolio> PortfolioRep;
        private IRepository<Contact> ContactRep;
        private IRepository<PageInfo> PageInfoRep;
        public HomeController()
        {
            var dbcontext = new lowataEntities();
            PortfolioRep = new Repository<Portfolio>(dbcontext);
            ContactRep = new Repository<Contact>(dbcontext);
            PageInfoRep = new Repository<PageInfo>(dbcontext);
        }

        public ActionResult Index()
        {
            ViewBag.Message = PageInfoRep.Get(c => c.PageTitle=="Home").Message;
            return View();
        }

        public ActionResult Services()
        {
            PageInfo pi = PageInfoRep.Get(c => c.PageTitle == "Services");
            return View(pi);
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = PageInfoRep.Get(c => c.PageTitle == "Portfolio").Message;
            ViewBag.Title = PageInfoRep.Get(c => c.PageTitle == "Portfolio").PageTitle;
            IList<Portfolio> Portfolios = PortfolioRep.GetAll().OrderByDescending(c=>c.UpdatedDate).ToList();
            return View(Portfolios);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = PageInfoRep.Get(c => c.PageTitle == "Contact").Message;
            ViewBag.Title = PageInfoRep.Get(c => c.PageTitle == "Contact").PageTitle;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                //Store DB
                ContactRep.Add(model);
                //Send email
                SendEmail(model);

                return PartialView("_ThankYou");
            }
            ModelState.AddModelError("Contact", "One or more contact errors were found");
          
            return PartialView("_ContactForm", model);
        }

        private void SendEmail(Contact model){
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
        }
     
    }
}
