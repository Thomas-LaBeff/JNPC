using Church_App.Data;
using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Church_App.Services.Business;


namespace Church_App.Areas.Pastor.Controllers
{
    [RouteArea("Pastor")]
    [Route("Pastor/[Controller]/[Action]")]
    public class MessageController : Controller
    {
        public ActionResult MessageIndex()
        {
            List<MessageModel> messages = new List<MessageModel>();

            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();

            messages = messageDAO.FetchAll();

            return View("MessageIndex", messages);
        }


        public ActionResult ServiceVideo()
        {
            List<MessageModel> messages = new List<MessageModel>();

            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();

            messages = messageDAO.FetchAll();

            return View("ServiceVideo", messages);
        }


        public ActionResult Details(int id)
        {
            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();
            MessageModel message = messageDAO.FetchOne(id);

            return View("Details", message);
            
        }

        public ActionResult Create()
        {
            return View("MessageForm");
        }

        public ActionResult Edit(int id)
        {
            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();
            MessageModel message = messageDAO.FetchOne(id);
            return View("MessageForm", message);
        }

        public ActionResult Delete(int id)
        {
            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();
            messageDAO.Delete(id);

            List<MessageModel> messages = messageDAO.FetchAll();

            return View("Index", messages);
        }

        public ActionResult ProcessCreate(MessageModel messageModel)
        {
            // save to database
            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();

            messageDAO.CreateOrUpdate(messageModel);

            return View("Details", messageModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchFields(string ServiceDate, string MessageTopic, string MessageTitle, string Message_ID, string Video)
        //public ActionResult SearchFields(string ServiceDate)
        {

            Pastor_MessageDAO messageDAO = new Pastor_MessageDAO();

            List<MessageModel> SearchResults = messageDAO.SearchFields(ServiceDate, MessageTopic, MessageTitle, Message_ID, Video);

            return View("Index", SearchResults);
        }
    }
}