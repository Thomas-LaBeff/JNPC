using Church_App.Data;
using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Church_App.Services.Business;


namespace Church_App.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class MessageController : Controller
    {

        public ActionResult ServiceVideo()
        {
            List<MessageModel> messages = new List<MessageModel>();

            Admin_MessageDAO messageDAO = new Admin_MessageDAO();

            messages = messageDAO.FetchAll();

            return View("ServiceVideo", messages);
        }
    }
}