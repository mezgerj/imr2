using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;

namespace Inspinia_MVC5.Controllers
{
    public class NavigationController : Controller
    {
        
        public ActionResult Navigation()
        {
            NavigationView model = new NavigationView();

            model.PopulateModel();

            return PartialView("_Navigation", model);
        }
    }
}