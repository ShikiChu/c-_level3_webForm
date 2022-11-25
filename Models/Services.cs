using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masterPage
{
    public class Services
    {
        public string Code { get; }
        public string ServiceItem { get; }
        public double ServiceHours { get; set; }

        //Constructor
        public Services(string code, string serviceItem)
        {
            Code = code;
            ServiceItem = serviceItem;
        }
    }
}