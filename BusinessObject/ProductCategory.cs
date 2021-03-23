using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;

namespace BusinessObject
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            ProductCategoryID = 0;
            ProductTypeID = 0;
            CategoryName = "";
            CategoryCode = "";
            Note = "";
            Activity = true;
            ProductTypeName = "";
            ProductTypeCode = "";
            ErrorMessage = "";
        }
        #region Property
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public string Note { get; set; }
        public bool Activity { get; set; }
        public string ErrorMessage { get; set; }
        #endregion
    }
    public interface IProductCategory
    {
        List<ProductCategory> Gets(int nBUID, int nUserID);
        List<ProductCategory> Gets(string sSQL, int nBUID, int nUserID);
        ProductCategory Get(int nID, int nProductCategoryID);
        ProductCategory IUD(ProductCategory oProductCategory, EnumDBOperation eEnumDBAction, int nUserID);
        List<ProductCategory> GetsByProductType(int nProductTypeID, int nUserID);
    }
}
