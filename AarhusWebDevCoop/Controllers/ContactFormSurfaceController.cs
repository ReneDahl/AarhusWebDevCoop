using AarhusWebDevCoop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        //This action controller returns a partialview called ContactPagePartial
        public ActionResult Index()
        {
            return PartialView("ContactPagePartial", new ContactForm());
        }

        // This action is using model binding, then this action is fired it will get the information from the model ContactForm. 
        // This action uses a ActionVerbs, that is a post Request.. It will be fired thouth a form..

        [HttpPost]
        public ActionResult CreateContent(ContactForm model)
        {
            return RedirectToCurrentUmbracoPage();
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            MailMessage message = new MailMessage();
            message.To.Add("rene1988dahl@gmail.com");
            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;


            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("rene1988dahl@gmail.com", "IsAllowed!");
                // send mail
               smtp.Send(message);

                TempData["success"] = true;
            }

            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "message");
            comment.SetValue("messageName", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("messageContent", model.Message);

            Services.ContentService.Save(comment);
    

            return RedirectToCurrentUmbracoPage();
        }

     
    }
}