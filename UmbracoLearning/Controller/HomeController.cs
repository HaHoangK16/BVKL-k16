using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace UmbracoLearning.Controller
{
    public class HomeController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Home/";
        public ActionResult RenderBanner()
        {
            return PartialView(string.Format("{0}Banner.cshtml", Partial_Views_Path));
        }

        public ActionResult RenderSectionOne()
        {
            return PartialView(string.Format("{0}SectionOne.cshtml", Partial_Views_Path));
        }

        public ActionResult RenderSectionTwo()
        {
            return PartialView(string.Format("{0}SectionTwo.cshtml", Partial_Views_Path));
        }

        public ActionResult RenderSectionThree()
        {
            return PartialView(string.Format("{0}SectionThree.cshtml", Partial_Views_Path));
        }
    }
}