using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class StoreProductHistoryDA
    {
        public static string IUD(StoreProductHistory oStoreProductHistoryHistory, EnumDBOperation oDBOperation, int nUserID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_StoreProduct");
        }
        public static string Gets(int nBUID, int nUserID)
        {
            return "SELECT * FROM View_StoreProductHistory ORDER BY DBServerDateTime DESC";
        }
        public static string GetsByStoreID(int nStoreID, int nUserID)
        {
            return "SELECT * FROM View_StoreProductHistory  WHERE StoreID = " + nStoreID;
        }
        public static string Gets(string sSQL, int nUserID)
        {
            return sSQL;
        }
        public static string Get(int nID, int nUserID)
        {
            return "SELECT * FROM View_StoreProductHistory WHERE [StoreProductHistoryID] =" + nID;
        }

    }
}


