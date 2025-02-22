using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebAppEntityFramework.Controllers
{
    public class FiltersDemoController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 30,Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            throw new Exception("This is my exception");
            //return View();
        }
        
        [HttpGet]
        [OutputCache(Duration = 30, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult About()
        {
            throw new Exception("This is my exception");
            //return View();
        }
        
        public ActionResult TestError()
        {
            throw new Exception("This is my exception");
        }
    }
}