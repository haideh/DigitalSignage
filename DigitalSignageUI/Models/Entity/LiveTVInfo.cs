using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class LiveTVInfo
    {
        public long id { get; set; }
        public int status { get; set; }
        public int type { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string channel { get; set; }
        public int interval { get; set; }
        public int position { get; set; }
        public long content_ad_id { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}