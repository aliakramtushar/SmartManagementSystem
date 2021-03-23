using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SMSEngine.GlobalClass
{
    public static class GlobalSession
    {
        public static string UserID = "UserID";
        public static string UserName = "UserName";
        public static string BaseAddress = "BaseAddress";
        public static string UserType = "UserType";
        public static void SessionIsAlive(HttpSessionStateBase Session, HttpResponseBase Response)
        {
            if (Session.Contents.Count == 0)
            {
                Response.Redirect("Timeout.html");
                //Response.Redirect("");
            }
        }


    }
}
