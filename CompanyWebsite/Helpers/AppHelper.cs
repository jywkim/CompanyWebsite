using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyWebsite.Helpers
{
    public class AppHelper
    {
        public static void SetFlash(Flash f)
        {
            HttpContext.Current.Session["flash"] = f;
        }
        public static void SetFlash(MessageType messageType, string msg)
        {
            Flash f = new Flash(messageType, msg);
            SetFlash(f);
        }

        public static Flash GetFlash()
        {
            return GetFlash(true);
        }
        public static Flash GetFlash(bool removeFromSession)
        {
            Flash f = (Flash)HttpContext.Current.Session["flash"];
            if (removeFromSession)
                SetFlash(null);
            return f;
        }
    }
}