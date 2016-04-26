using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class TvCategoreisInfo
    {
        public long id { get; set; }
        public int status { get; set; }
        public int type { get; set; }
        public long parent_id { get; set; }
        public string title { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}