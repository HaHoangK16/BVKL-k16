using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using UmbracoLearning.Models;
using System.Net.Mail;

namespace UmbracoLearning.Controller
{
    public class CommentsController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/New/";
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderComment()
        {
            return PartialView(string.Format("{0}Comment.cshtml", Partial_Views_Path));
        }

        public ActionResult RenderCommentator()
        {
            return PartialView(string.Format("{0}Commentator.cshtml", Partial_Views_Path));
        }

        public ActionResult HandleSubmitCommentForm(CommentsModel model)
        {
            if (ModelState.IsValid)
            {
                var message = Services.ContentService
                    .Create(String.Format("{0} - {1}", model.txtName, DateTime.Now.ToString()),
                    CurrentPage.Id, "commentsDetail");

                //message.SetCultureName("commentName", "en-US");
                //message.SetCultureName("commentemail", "en-US");
                //message.SetCultureName("commentphone", "en-US");
                //message.SetCultureName("commentmessage", "en-US");

                message.SetValue("commentName", model.txtName);
                message.SetValue("commentemail", model.txtEmail);
                message.SetValue("commentphone", model.txtPhone);
                message.SetValue("commentmessage", model.txtMsg);

                TempData["CommentsUsSuccess"] = true;
                //message.SetValue("umbracoNaviHide", true);

                Services.ContentService.SaveAndPublish(message);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
    }
}