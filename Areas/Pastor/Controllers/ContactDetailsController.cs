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
    [Route]
    public class ContactDetailsController : Controller
    {
        public ActionResult ContactDetails()
        {
            List<ContactDetailsModel> contactDetails = new List<ContactDetailsModel>();

            Contact_Details_DAO cd_DAO = new Contact_Details_DAO();

            contactDetails = cd_DAO.FetchResult();
            return View("ContactDetails", contactDetails);
        }

        public ActionResult NeedToContact()
        {
            List<NeedToContactModel> contactDetails2 = new List<NeedToContactModel>();

            Contact_Details_DAO cd_DAO = new Contact_Details_DAO();

            contactDetails2 = cd_DAO.NeedToContact();
            return View("NeedToContact", contactDetails2);
        }

    }
}