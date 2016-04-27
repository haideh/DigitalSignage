using Aryaban.Engine.Core.WebService;
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
            ContentInfo c = new ContentInfo();
            c.content_id = Convert.ToInt64(contentId);
            return View(c);
        }
        public ActionResult EditContentSelector(string contentId, string type, string position)
        {
            ViewData["contentId"] = contentId;
            ViewData["type"] = type;
            ViewData["position"] = position;
            return View();
        }


        [HttpPost]
        public ActionResult loadAdsListWithType(long type)
        {
            AdsServiceProxy serviceProxy = new AdsServiceProxy();
            ResultMessage<List<AdsInfo>> adsList = serviceProxy.loadAdsItemListWithType(type, 1);

            if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                //Redirect To Error Page
                return RedirectToAction("Error", "Error");

            JsonResult result = new JsonResult();
            result.Data = adsList;
            return result;
        }
        [HttpPost]
        public ActionResult loadWidgetAdsItemListWithType()
        {
            AdsServiceProxy serviceProxy = new AdsServiceProxy();
            ResultMessage<List<AdsInfo>> adsList = serviceProxy.loadWidgetAdsItemListWithCompanyId(1);

            if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                //Redirect To Error Page
                return RedirectToAction("Error", "Error");

            JsonResult result = new JsonResult();
            result.Data = adsList;
            return result;
        }

        [HttpPost]
        public ActionResult loadContentAdsListWithPoition(string type, string contentId, string position)
        {
            ContentProxy serviceProxy = new ContentProxy();
            ResultMessage<List<AdsInfo>> adsList = serviceProxy.searchContentPositionAdsItem(type, contentId, position);

            if (adsList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                //Redirect To Error Page
                return RedirectToAction("Error", "Error");

            JsonResult result = new JsonResult();
            result.Data = adsList;
            return result;
        }

        [HttpPost]
        public ActionResult editContentAds(ContentOptionInfo contentOptionInfo)
        {
            ContentProxy serviceProxy = new ContentProxy();
            ResultMessage<string> contentAds = serviceProxy.editContentAds(contentOptionInfo);

            if (contentAds.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                return RedirectToAction("Error", "Error");
            return RedirectToAction("EditContent", new RouteValueDictionary(new { contentId = contentOptionInfo.content_id.ToString() }));
        }
    }
}