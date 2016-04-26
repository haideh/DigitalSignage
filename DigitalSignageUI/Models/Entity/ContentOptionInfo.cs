using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class ContentOptionInfo
    {
  
        public long id { get; set; }
        public long content_id { get; set; }
        public int position { get; set; }
        public int second { get; set; }
        public int shuffle { get; set; }
        public int interval { get; set; }
        public long live_id { get; set; }
        public long ad_id { get; set; }
        public long createDateTime { get; set; }
        public string description { get; set; }
        public int secondViewed { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }

    }
}