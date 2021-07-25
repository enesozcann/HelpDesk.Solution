using HelpDesk.Common;
using HelpDesk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk.WebApp.Models
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUserName()
        {
            if(HttpContext.Current.Session["auth-user"] != null)
            {
                HDUser user = HttpContext.Current.Session["auth-user"] as HDUser;
                return user.UserName;
            }
            return null;
        }
    }
}