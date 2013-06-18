using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EliseCouture.Web.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.EmailValid = true;
            ViewBag.MessageValid = true;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                using (var mail = new MailMessage(contact.Email, "elise@amoryfitness.com", "amoryfitness.com", contact.Message))
                using (var smtp = new SmtpClient("smtp.sendgrid.net", 587))
                {
                    smtp.Timeout = 5;
                    smtp.Credentials = new NetworkCredential("azure_7c165ef7e5cfef3ef43a3052a389bd47@azure.com", "89wtgmfd");
                    smtp.Send(mail);
                    return RedirectToAction("received");
                }
            }
            ViewBag.EmailValid = ModelState.IsValidField("Email");
            ViewBag.MessageValid = ModelState.IsValidField("Message");
            return View(contact);
        }

        [HttpGet]
        public ActionResult Received()
        {
            return View();
        }

    }

    public class ContactModel
    {
        [Required(ErrorMessage="Email address required"), EmailAddress(ErrorMessage="Please use a valid email address"), Display(Name="Your email address")]
        public string Email { get; set; }

        [Required(ErrorMessage="Say something!"), Display(Name="Any questions or comments")]
        public string Message { get; set; }
    }
}
