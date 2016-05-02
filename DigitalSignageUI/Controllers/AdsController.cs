﻿using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models;
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
    public class AdsController : Controller
    {

        // [Authorize]
        public ActionResult AdsManagement()
        {
            if (SessionManage.getUserSession() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        public ActionResult AdsList()
        {
            if (SessionManage.getUserSession() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        [HttpPost]
        public ActionResult saveAds(AdsInfo adsInfo)
        {
            if (SessionManage.getUserSession() != null)
            {
                AdsServiceProxy serviceProxy = new AdsServiceProxy();
                ResultMessage<string> contentAds = serviceProxy.saveAds(adsInfo);

                if (contentAds.result.status == Aryaban.Engine.Core.WebService.Result.state.error)
                {
                    var redirectErrorUrl = new UrlHelper(Request.RequestContext).Action("Error", "Error");
                    return Json(new { Url = redirectErrorUrl });
                }
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        [HttpPost]
        public void uploadFile()
        {
            if (SessionManage.getUserSession() != null)
            {
                var httpPostedFile = Request.Files["UploadedFile"];
                var filename = Request.Params["filename"];
                byte[] file = ReadToEnd(httpPostedFile.InputStream);


                AdsServiceProxy serviceProxy = new AdsServiceProxy();
                serviceProxy.uploadFile(file, filename);

                //return View();
                RedirectToAction("AdsManagement");
            }
            else
            {
                RedirectToAction("login", "Login");
            }

        }


        [HttpPost]
        public ActionResult getAdsList()
        {
            if (SessionManage.getUserSession() != null)
            {
                AdsServiceProxy serviceProxy = new AdsServiceProxy();
                ResultMessage<List<AdsInfo>> adsList = serviceProxy.getAdsList(SessionManage.getUserSession().companyId);

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

        private static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

    }
}