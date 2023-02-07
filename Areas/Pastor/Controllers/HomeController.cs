using System;
using Church_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Church_App.Data;

namespace Church_App.Areas.Pastor.Controllers
{
    [RouteArea("Pastor")]
    [Route("Pastor/[Controller]/[Action]")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}