using Church_App.Models;
using Church_App.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Church_App.Services.Business
{
    public class AdminSecurityService
    {
        AdminSecurityDAO daoService = new AdminSecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
    }
}