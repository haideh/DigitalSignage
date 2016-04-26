using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class ContentType
    {
        public long id { get; set; }
        public string title { get; set; }
        public string file_name { get; set; }
        public string body { get; set; }
        public int status { get; set; }
        public int type { get; set; }
        public long companyId { get; set; }
        public string companyName { get; set; }
    }
}