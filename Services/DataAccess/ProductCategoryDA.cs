using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class ProductCategoryDA
    {
        public static string IUD(ProductCategory oProductCategory, EnumDBOperation eDBAction, int userID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_ProductCategory", oProductCategory.ProductCategoryID, oProductCategory.CategoryName, oProductCategory.CategoryCode, oProductCategory.ProductTypeID, oProductCategory.Activity, oProductCategory.Note, (int)eDBAction, userID);
        }
        public static string Gets(int nBUID, int nProductCategory)
        {
            return "SELECT * FROM View_ProductCategory ORDER BY CategoryName";
        }
        public static string Gets(string sSQL, int nBUID, int nProductCategory)
        {
            return sSQL;
        }
        public static string Gets(string sSQL, int nProductCategory)
        {
            return sSQL;
        }
        public static string Get(int nID, int nProductCategoryID)
        {
            return "SELECT * FROM View_ProductCategory WHERE [ProductCategoryID] =" + nID;
        }
        public static string GetsByProductType(int nProductType, int nUserID)
        {
            return "SELECT * FROM View_ProductCategory WHERE ProductTypeID =" + nProductType + "ORDER BY CategoryName";
        }
    }
}
