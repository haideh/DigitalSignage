using Aryaban.Engine.Core.HttpRequest.Session;
using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models
{
    public class SessionManage
    {
        public static void setSession(string key, object value)
        {
            System.Web.HttpContext.Current.Session[key] = value;
        }

        public static Object getSession(string key)
        {
            return System.Web.HttpContext.Current.Session[key];
        }


        #region User Sessions
        public static void setUserSession(UserInfo value)
        {
            System.Web.HttpContext.Current.Session[SessionConstants.K_USER] = value;
        }

        public static UserInfo getUserSession()
        {
            return (UserInfo)System.Web.HttpContext.Current.Session[SessionConstants.K_USER];
        }

        public static void ClearSession()
        {
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();
        }
        #endregion
    }
}