using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Entity
{
    public class UserInfo
    {

        public long id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int companyId { get; set; }
    }
}