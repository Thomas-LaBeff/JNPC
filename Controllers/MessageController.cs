using Church_App.Data;
using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Church_App.Services.Business;


namespace Church_App.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult ServiceVideo()
        {
            List<MessageModel> messages = new List<MessageModel>();

            MessageDAO messageDAO = new MessageDAO();

            messages = messageDAO.FetchSunAM();

            return View("ServiceVideo", messages);
        }
    }
}