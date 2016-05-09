using Ariaban.Parser.HTML;
using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models;
using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.Models.ServiceProxy;
using DigitalSignageUI.TvsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace DigitalSignageUI.Controllers
{
    public class ShowController : Controller
    {

        public ActionResult ShowContent()
        {
            //ContentInfo c = new ContentInfo();
            //c.content_id = Convert.ToInt64("20049");
            return View();
        }


        private ResultMessage<ContentInfo> readConfig()
        {

            string path = (System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "/data/ads");
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

            ContentServiceProxy serviceProxy = new ContentServiceProxy();
            ResultMessage<ContentInfo> contents = serviceProxy.getContentInfoByConfig(Ip, companyName);

            return contents;



        }

      
        //Load Content
        [HttpPost]
        public ActionResult loadContent(long content_id, long lastAlive)
        {

            ContentServiceProxy serviceProxy = new ContentServiceProxy();
            ResultMessage<List<AdsInfo>> contentList = serviceProxy.loadContent(content_id, lastAlive);


            string path = (System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "/data/ads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            List<string> fileName = new List<string>();

            if (contentList.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
            {
                var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                return Json(new { Url = redirectErrorUrl });
            }

            foreach (var item in contentList.resultSet)
            {

                foreach (var itemDetail in item.itemList)
                {
                    fileName.Add(itemDetail.file_name);
                    if (item.status == 1 &&(item.type==1 || item.type == 2))//change_Download
                        download(path, itemDetail.file_name, item.type);

                }
            }

            //Delete Other File
            foreach (string item in Directory.GetFiles(path))
            {
                if (path.ToLower().Contains("Thumbs.db".ToLower()))
                {
                    continue;
                }
                if (!fileName.Contains(Path.GetFileName(item)))
                    System.IO.File.Delete(item);
            }

            JsonResult result = new JsonResult();
            result.Data = contentList;
            return result;

        }

        private void download(string path, string filename, int type)
        {
            HttpRequestAPI instant = new HttpRequestAPI();
            string url = "";
            if (type == 1)//Image
                url = WebConfigurationManager.AppSettings["imageSource"] + filename;
            if (type == 2)//movie
                url = WebConfigurationManager.AppSettings["videoSource"] + filename;
            instant.downloader(url, path + '\\', filename, true, false, true, 20000000);

            //WebClient client = new WebClient();
            //client.DownloadFileAsync(e.Url,"");

        }

        #region Tv
        [HttpPost]
        public ActionResult isDirty(long tvId)
        {
            
            TvProxy serviceProxy = new TvProxy();
            ResultMessage<TvsInfo> contentAds = serviceProxy.isDirty(tvId);

            JsonResult result = new JsonResult();
            result.Data = contentAds;
            return result;


        }
        public ActionResult getTvInfo(string tvKey)
        {

            TvProxy serviceProxy = new TvProxy();
            ResultMessage<List<TvContentsInfo>> tvList = serviceProxy.getTvInfoById(tvKey);
            JsonResult result = new JsonResult();
            result.Data = tvList;
            return result;

        }

        #endregion
    }
}