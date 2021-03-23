using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class StoreProductDA
    {
        public static string IUD(StoreProduct oStoreProduct, EnumDBOperation oDBOperation, int nUserID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_StoreProduct",
                oStoreProduct.StoreProductID, oStoreProduct.StoreID, oStoreProduct.ProductID, oStoreProduct.ContractorID, oStoreProduct.ProductQty, oStoreProduct.ProductNewQty,
                oStoreProduct.Remarks, oStoreProduct.CustomerName, oStoreProduct.Rate, (int)oDBOperation, nUserID);
        }
        public static string Gets(int nUserID)
        {
            return "SELECT * FROM View_StoreProduct ORDER BY ProductName";
        }
        public static string GetsByStoreID(int nStoreID, int nUserID)
        {
            return "SELECT * FROM View_StoreProduct WHERE StoreID = " + nStoreID;
        }
        public static string Gets(string sSQL, int nUserID)
        {
            return sSQL;
        }
        public static string Get(int nStoreID, int nProductID, int nUserID)
        {
            return "SELECT * FROM View_StoreProduct WHERE StoreID =" + nStoreID + " AND ProductID =" + nProductID;
        }

    }
}

