using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class AlarmsInfo
    {
        public string id { get; set; }
        public string message { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}