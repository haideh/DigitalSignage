using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models;
using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.Models.ServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DigitalSignageUI.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult EditContent(string contentId)
        {
            if (SessionManage.getUserSession() != null)
            {
                ContentInfo c = new ContentInfo();
                c.content_id = Convert.ToInt64(contentId);
                return View(c);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }
        public ActionResult EditContentSelector(string contentId, string type, string position)
        {
            if (SessionManage.getUserSession() != null)
            {
                ViewData["contentId"] = contentId;
                ViewData["type"] = type;
                ViewData["position"] = position;
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }


        [HttpPost]
        public ActionResult loadAdsListWithType(long type, string contentId, string position)
        {
            if (SessionManage.getUserSession() != null)
            {
                AdsServiceProxy serviceProxy = new AdsServiceProxy();
                ResultMessage<List<AdsInfo>> adsList = serviceProxy.loadAdsItemListWithType(type, SessionManage.getUserSession().companyId, contentId, position);

                if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }

                JsonResult result = new JsonResult();
                result.Data = adsList;
                return result;
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }
        [HttpPost]
        public ActionResult loadWidgetAdsItemListWithType()
        {
            if (SessionManage.getUserSession() != null)
            {
                AdsServiceProxy serviceProxy = new AdsServiceProxy();
                ResultMessage<List<AdsInfo>> adsList = serviceProxy.loadWidgetAdsItemListWithCompanyId(SessionManage.getUserSession().companyId);

                if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }

                JsonResult result = new JsonResult();
                result.Data = adsList;
                return result;
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        [HttpPost]
        public ActionResult loadContentAdsListWithPoition(string type, string contentId, string position)
        {
            if (SessionManage.getUserSession() != null)
            {
                ContentServiceProxy serviceProxy = new ContentServiceProxy();
                ResultMessage<List<AdsInfo>> adsList = serviceProxy.searchContentPositionAdsItem(type, contentId, position);

                if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }

                JsonResult result = new JsonResult();
                result.Data = adsList;
                return result;
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        [HttpPost]
        public ActionResult editContentAds(ContentOptionInfo contentOptionInfo)
        {
            if (SessionManage.getUserSession() != null)
            {
                ContentServiceProxy serviceProxy = new ContentServiceProxy();
                ResultMessage<string> contentAds = serviceProxy.editContentAds(contentOptionInfo);

                if (contentAds.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }
                return RedirectToAction("EditContent", new RouteValueDictionary(new { contentId = contentOptionInfo.content_id.ToString() }));
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }




        [HttpPost]
        public ActionResult deleteContentAds(long content_id, int position)
        {
            if (SessionManage.getUserSession() != null)
            {
                ContentServiceProxy serviceProxy = new ContentServiceProxy();
                ResultMessage<string> contentAds = serviceProxy.deleteContentAds(content_id, position);

                if (contentAds.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }
                return RedirectToAction("EditContent", new RouteValueDictionary(new { contentId = content_id.ToString() }));
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }


        #region Live

        [HttpPost]
        public ActionResult loadContentLiveVedio(long contentId, int position)
        {
            if (SessionManage.getUserSession() != null)
            {
                LiveServiceProxy serviceProxy = new LiveServiceProxy();
                ResultMessage<List<LiveTVInfo>> adsList = serviceProxy.loadLiveVedioContent(contentId, SessionManage.getUserSession().companyId, position);

                if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }

                JsonResult result = new JsonResult();
                result.Data = adsList;
                return result;
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }


        [HttpPost]
        public ActionResult loadLiveVedioContentWithPosition(long contentId, int position)
        {
            if (SessionManage.getUserSession() != null)
            {
                LiveServiceProxy serviceProxy = new LiveServiceProxy();
                ResultMessage<List<LiveTVInfo>> adsList = serviceProxy.loadContentLiveVedioWithPosition(contentId, position);

                if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                };

                JsonResult result = new JsonResult();
                result.Data = adsList;
                return result;
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }


        #endregion
    }
}