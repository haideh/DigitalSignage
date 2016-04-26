using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class StoresInfo
    {
        public long id { get; set; }
        public int category_id { get; set; }
        public int map_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int unit { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public int status { get; set; }
        public int type { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string image { get; set; }
        public string startWorkTime { get; set; }
        public string endWorkTime { get; set; }
        public string workingDay { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}