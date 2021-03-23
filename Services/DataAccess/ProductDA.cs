using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class ProductDA
    {
        public static string IUD(Product oProduct, EnumDBOperation oDBOperation, int nUserID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_Product",
                oProduct.ProductID, oProduct.ProductName, oProduct.ProductCode, oProduct.ProductTypeID, oProduct.ProductCategoryID, oProduct.UnitPrice, (int)oDBOperation, nUserID);
        }
        public static string Gets(int nBUID, int nUserID)
        {
            return "SELECT * FROM View_Product";
        }
        public static string Gets(string sSQL, int nBUID, int nUserID)
        {
            return sSQL;
        }
        public static string GetsProductByTypeAndCategory(string nProductName, int nProductTypeID, int nCategory, int nUserID)
        {
            return "SELECT * FROM View_Product WHERE ProductName LIKE '%"+ nProductName +"%' AND ProductTypeID = " + nProductTypeID + " AND ProductCategoryID = " + nCategory + " ORDER BY ProductName";
        }
        public static string Get(int nProductID, int nUserID)
        {
            return "SELECT * FROM View_Product WHERE [ProductID] =" + nProductID;
        }
    }
}
