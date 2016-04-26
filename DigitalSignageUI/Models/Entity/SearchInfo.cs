using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class FieldInfo
    {
        public string title { get; set; }
        public string type { get; set; }
    }
    public class OrderInfo
    {
        public string orderName { get; set; }
        public string sortType { get; set; }
    }
    public class PagingInfo
    {
        public List<OrderInfo> orderLst { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

    }
}