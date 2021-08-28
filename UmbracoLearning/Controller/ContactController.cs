using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using UmbracoLearning.Models;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace UmbracoLearning.Controller
{

    public class ContactController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/SharedLayout/";
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderContact()
        {
            return PartialView(string.Format("{0}ContactPartial.cshtml", Partial_Views_Path));
        }

        public ActionResult HandleSubmitForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var message = Services.ContentService
                    .Create(String.Format("{0} - {1}", model.Name, DateTime.Now.ToString()),
                    CurrentPage.Id, "contactContent");

                message.SetCultureName("userName", "en-US");
                message.SetCultureName("email", "en-US");
                message.SetCultureName("message", "en-US");

                message.SetValue("userName", model.Name);
                message.SetValue("email", model.Email);
                message.SetValue("message", model.Message);

                TempData["ContactUsSuccess"] = true;
                //message.SetValue("umbracoNaviHide", true);

                Services.ContentService.SaveAndPublish(message);
                //SendMail(model);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        //private void SendMail(ContactModel model)
        //{
            //Cach 2: send email
            //var fromEmail = new MailAddress(ConfigurationManager.AppSettings["SendEmailFrom"]);
            //var toAddress = new MailAddress(model.Email);

            //string subject = ConfigurationManager.AppSettings["EmailSubject"];
            //string body = model.Message;
            //var message = new MailMessage(fromEmail, toAddress)
            //{
                //Subject = subject,
                //Body = body
            //};

            //connect to SMTP credentials in web.config
            //try
            //{
                //var smtp = new SmtpClient();
                //smtp.Send(message);
            //}
            //catch (Exception ex)
            //{
                //throw ex;
            //}

        }
    }