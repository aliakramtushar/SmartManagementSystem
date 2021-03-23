using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class UserDA
    {
        public static string IUD(User oUser, EnumDBOperation oDBOperation, int nUserID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_User", 
                oUser.UserID, oUser.UserName, oUser.UserShortName, oUser.Password, (int)oUser.UserType, oUser.Email, oUser.Mobile,
                oUser.Code, oUser.Validity, oUser.Activity, (int)oDBOperation, nUserID);
        }
        public static string ValidateLogin(int nBUID, User oUser)
        {
            return "SELECT * FROM View_User WHERE [UserName] = '"+ oUser.UserName + "' AND [Password] = '"+ oUser .Password+ "' AND Activity = 1 AND Validity = 1";
        }
        public static string Gets(int nBUID, int nUser)
        {
            return "SELECT * FROM View_User";
        }
        public static string Gets(string sSQL, int nBUID, int nUser)
        {
            return sSQL;
        }
        public static string Get(int nID, int nUserID)
        {
            return "SELECT * FROM View_User WHERE [UserID] =" + nID;
        }

    }
}
