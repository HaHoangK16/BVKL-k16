using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace UmbracoLearning.Controller
{
    public class ElementsController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Elements/";
        public ActionResult RenderElementsMainContent()
        {
            return PartialView(string.Format("{0}ElementsMainContent.cshtml", Partial_Views_Path));
        }
    }
}