using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class Product
    {
        public Product()
        {
            ProductID = 0;
            ProductCategoryID = 0;
            ProductName = "";
            ProductCode = "";
            CategoryCode = "";
            CategoryName = "";
            UnitPrice = 0.00;
            ProductTypeID = 0;
            ProductTypeName ="";
            ProductTypeCode ="";
            ErrorMessage = "";
        }
        #region Property
        public int ProductID { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public double UnitPrice { get; set; }
        public string ErrorMessage { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        #endregion

        #region Derived Property
        #endregion
    }
    public interface IProduct
    {
        List<Product> Gets(int nBUID, int nProduct);
        List<Product> Gets(string sSQL, int nBUID, int nProduct);
        List<Product> GetsProductByTypeAndCategory(string nProductName, int nProductTypeID, int nCategory, int nUserID);
        Product Get(int nID, int nProductID);
        Product IUD(Product oProduct, int nUnserID);
        string Delete(Product oProduct, int nProductID);
    }
}
