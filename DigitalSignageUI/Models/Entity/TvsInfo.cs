using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class TvsInfo
    {
        public long id { get; set; }
        public long category_id { get; set; }
        public long alarm_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string ip { get; set; }
        public int status { get; set; }
        public int content_id { get; set; }
        public int type { get; set; }
        public int isDirty { get; set; }
        public long lastAlive { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}