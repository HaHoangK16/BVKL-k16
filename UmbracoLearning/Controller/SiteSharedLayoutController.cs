using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using UmbracoLearning.Models;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace UmbracoLearning.Controller
{
    public class SiteSharedLayoutController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/SharedLayout/";

        public ActionResult RenderFooter()
        {
            return PartialView(string.Format("{0}Footer.cshtml", Partial_Views_Path));
        }


        public ActionResult RenderHeader()
        {
            List<NavigationList> nav = GetNavigationModel();
            //return PartialView((string.Format("{0}Header.cshtml", Partial_Views_Path)), nav);
            return PartialView( Partial_Views_Path + "Header.cshtml",nav);
        }

        // step 1: create function to get the Navigation model from database
        // step 2: write the code to get the sub Navigation
        // step 3: Update the code for RenderHeader

        public List<NavigationList> GetNavigationModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]); //there are the page position in path
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new List<NavigationList>
            {
                new NavigationList(new NavigationLinkInfo(pageInfo.Url, pageInfo.Name))
            };
            nav.AddRange(GetSubNavigationList(pageInfo));
            return nav;
        }

        public List<NavigationList> GetSubNavigationList(IPublishedContent page)
        {
            List<NavigationList> navList = null;
            var subPages = page.Children.Where(x => x.IsVisible());
            if (subPages.Count() >= 0)
            {
                navList = new List<NavigationList>();
                foreach (var subPage in subPages)
                {
                    var listItem = new NavigationList(new NavigationLinkInfo(subPage.Url, subPage.Name))
                    {
                        NavItems = GetSubNavigationList(subPage)
                    };
                    navList.Add(listItem);
                }
            }
            return navList;
        }
    }
}