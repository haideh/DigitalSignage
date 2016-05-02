using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models;
using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.Models.ServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DigitalSignageUI.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginFunction(UserInfo model)
        {
            if (ModelState.IsValid)
            {

                PermissionServiceProxy serviceProxy = new PermissionServiceProxy();
                ResultMessage<string> security = serviceProxy.login(model);

                if (security.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }
                FormsAuthentication.SetAuthCookie(model.username, false);

                var redirectUrl = new UrlHelper(Request.RequestContext).Action("AdsList", "Ads");
                return Json(new { Url = redirectUrl });
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignUpFunction(UserInfo model)
        {
            PermissionServiceProxy serviceProxy = new PermissionServiceProxy();
            ResultMessage<string> security = serviceProxy.signUp(model);

            if (security.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
            {
                var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                return Json(new { Url = redirectErrorUrl });
            }
            FormsAuthentication.SetAuthCookie(model.username, false);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("AdsList", "Ads");
            return Json(new { Url = redirectUrl });

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            SessionManage.ClearSession();
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("login", "Login");
            return Json(new { Url = redirectUrl });
           
        }


    }
}