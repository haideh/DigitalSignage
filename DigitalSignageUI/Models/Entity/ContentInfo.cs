using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class ContentInfo
    {
        public long id { get; set; }
        public long tv_id { get; set; }
        public long content_id { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public int duration { get; set; }
        public int status { get; set; }
        public int type { get; set; }
        public long lastViewed { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string file_name { get; set; }
        public string ad_title { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}