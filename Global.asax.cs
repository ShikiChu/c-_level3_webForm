using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace masterPage
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            PlatinumMember.MaxHours = 5;
            PlatinumMember.MaxNumOfService = 4;
            GoldMember.MaxHours = 4;
            GoldMember.MaxNumOfService = 3;
            BronzeMember.MaxHours = 3;
            BronzeMember.MaxNumOfService = 2;
        }
    }
}