using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class TvContentsInfo
    {
        public long id { get; set; }

        public long tv_id { get; set; }

        public long content_id { get; set; }

        public long startTime { get; set; }

        public long endTime { get; set; }

        public int duration { get; set; }

        public short status { get; set; }

        public long lastViewed { get; set; }

        public long companyId { get; set; }

        public long lastAlive { get; set; }

        public string rootAddress { get; set; }

        public string ip { get; set; }

        public int type { get; set; }

        public int isDirty { get; set; }


        public int x { get; set; }

        public int y { get; set; }


    }
}