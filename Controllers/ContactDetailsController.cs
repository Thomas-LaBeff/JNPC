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
    public class ContactDetailsController : Controller
    {
        // GET: ContactDetails
        public ActionResult ContactDetails_Index()
        {
            List<ContactDetailsModel> contactDetails = new List<ContactDetailsModel>();

            Contact_Details_DAO cd_DAO = new Contact_Details_DAO();

            contactDetails = cd_DAO.FetchResult();
            return View("ContactDetails_Index", contactDetails);
        }

        public ActionResult Index()
        {
            List<ContactDetailsModel> contactDetails = new List<ContactDetailsModel>();

            Contact_Details_DAO cd_DAO = new Contact_Details_DAO();

            contactDetails = cd_DAO.FetchResult();
            return View("~/Pastor/Home/Index", contactDetails);
        }
    }
}