using Church_App.Data;
using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Church_App.Services.Business;


namespace Church_App.Areas.Member.Controllers
{
    [RouteArea("Member")]
    [Route("Member/[Controller]/[Action]")]
    public class MessageController : Controller
    {
        public ActionResult ServiceVideo()
        {
            List<MessageModel> messages = new List<MessageModel>();

            Member_MessageDAO messageDAO = new Member_MessageDAO();

            messages = messageDAO.FetchAll_ServiceVideos();

            return View("ServiceVideo", messages);
        }
    }
}