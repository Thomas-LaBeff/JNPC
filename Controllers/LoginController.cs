using Church_App.Models;
using Church_App.Data;
using Church_App.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Church_App.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult MemberLogin(UserModel userModel)
        {
            MemberSecurityService securityService = new MemberSecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                return View("~/Areas/Member/Views/Home/Index.cshtml");
            }
            else
            {
                return View("MemberLogin");
            }
        }

        public ActionResult AdminLogin(UserModel userModel)
        {
            AdminSecurityService securityService = new AdminSecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                return View("~/Areas/Admin/Views/Home/Index.cshtml");
            }
            else
            {
                return View("AdminLogin");
            }
        }

        public ActionResult PastorLogin(UserModel userModel)
        {
            PastorSecurityService securityService = new PastorSecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                return View("~/Areas/Pastor/Views/Home/Index.cshtml");
            }
            else
            {
                return View("PastorLogin");
            }
        }

    }
}