using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class StoreDA
    {
        public static string IUD(Store oStore, EnumDBOperation oDBOperation, int nStoreID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_Store",
                oStore.StoreID, oStore.StoreName, oStore.StoreShortName, oStore.Capacity, (int)oDBOperation, nStoreID);
        }
        public static string Gets(int nBUID, int nUserID)
        {
            return "SELECT * FROM View_Store ORDER BY StoreName";
        }
        public static string Gets(string sSQL, int nBUID, int nStore)
        {
            return sSQL;
        }
        public static string Get(int nStoreID, int nUserID)
        {
            return "SELECT * FROM View_Store WHERE [StoreID] =" + nStoreID;
        }

    }
}
