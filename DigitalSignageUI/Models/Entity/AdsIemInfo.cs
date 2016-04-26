using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class AdsIemInfo
    {
       
        public long id { get; set; }
       
        public long ad_id { get; set; }
       
        public string title { get; set; }
       
        public string description { get; set; }
       
        public string file_name { get; set; }
       
        public int status { get; set; }
       
        public int type { get; set; }
       
        public int minutes { get; set; }
       
        public long datetime { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}