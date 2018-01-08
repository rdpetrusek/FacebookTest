using System;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using FacebookTest.Models.CustomerTracking;
using System.Web.Mvc;
using Newtonsoft.Json;
using HttpPost = System.Web.Http.HttpPostAttribute;
using HttpGet = System.Web.Http.HttpGetAttribute;
using System.Net;

namespace FacebookTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}