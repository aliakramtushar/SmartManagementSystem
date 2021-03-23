using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class ProductTypeDA
    {
        public static string IUD(ProductType oProductType, EnumDBOperation eDBAction, int userID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_ProductType", oProductType.ProductTypeID, oProductType.ProductTypeName, oProductType.ProductTypeCode, (int)eDBAction, userID);
        }
        public static string Gets(int nBUID, int nProductType)
        {
            return "SELECT * FROM ProductType ORDER BY ProductTypeName";
        }
        public static string Gets(string sSQL, int nBUID, int nProductType)
        {
            return sSQL;
        }
        public static string Get(int nID, int nProductTypeID)
        {
            return "SELECT * FROM ProductType WHERE [ProductTypeID] = " + nID + " ORDER BY ProductTypeName";
        }
    }
}

