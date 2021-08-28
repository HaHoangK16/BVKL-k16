using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace UmbracoLearning.Controller
{
    public class GenericController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Generic/";
        public ActionResult RenderGenericMainContent()
        {
            return PartialView(string.Format("{0}GenericMainContent.cshtml", Partial_Views_Path));
        }
    }
}