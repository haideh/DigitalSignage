using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.Models.ServiceProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalSignageUI.Controllers
{
    public class ShowController : Controller
    {

        public ActionResult ShowContent(string Id, string type)
        {
            ContentInfo c = new ContentInfo();

            if (string.IsNullOrEmpty(Id))//Read From Config
            {

                c.content_id = 20047;
                return View(c);

                //ResultMessage<ContentInfo> result =readConfig();
                //if (result.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                //    return RedirectToAction("Error", "Error");
                //else
                //    // ViewData["contentId"] = contentId;
                //    return View(result.resultSet);
            }

            else if (type == "c")//See Content
            {
                c.content_id = Convert.ToInt64(Id);
                return View(c);
            }
            else //See Tv
            {
                ResultMessage<List<ContentInfo>> result = getTvContent(Convert.ToInt64(Id));
                if (result.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                    return RedirectToAction("Error", "Error");
                else
                    return View(result.resultSet.FirstOrDefault());
            }
        }


        private ResultMessage<ContentInfo> readConfig()
        {
            string path = (System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "/data/config.txt");
            string sText = "";
            using (StreamReader reader = new StreamReader(path))
            {
                sText = reader.ReadToEnd();
                reader.Close();
            }
            List<string> configList = sText.Split(',').ToList<string>();
            // string Ip = configList[0].Replace("IP:", "").Trim();
            string Ip = Request.UserHostAddress.ToString();
            string companyName = configList[1].Replace("CompanyName:", "").Trim().ToLower();

            ContentProxy serviceProxy = new ContentProxy();
            ResultMessage<ContentInfo> contents = serviceProxy.getContentInfoByConfig(Ip, companyName);

            return contents;

        }

        private ResultMessage<List<ContentInfo>> getTvContent(long tvId)
        {
            ContentProxy serviceProxy = new ContentProxy();
            ContentsServices.ContentInfoWTO filter = new ContentsServices.ContentInfoWTO();
            filter.tv_id = tvId;
            ResultMessage<List<ContentInfo>> contentList = serviceProxy.getContentInfoBytvId(filter, null);
            return contentList;

        }

        //Load Content
        [HttpPost]
        public ActionResult loadContent(long content_id)
        {
            ContentProxy serviceProxy = new ContentProxy();
            ResultMessage<List<AdsInfo>> contentList = serviceProxy.loadContentsWithAdsItemDetail(content_id);

            if (contentList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                //Redirect To Error Page
                return RedirectToAction("Error", "Error");

            JsonResult result = new JsonResult();
            result.Data = contentList;
            return result;
        }
    }
}