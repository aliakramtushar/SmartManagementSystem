using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;

namespace BusinessObject
{
    public class ProductType
    {
        public ProductType()
        {
            ProductTypeID = 0;
            ProductTypeName = "";
            ProductTypeCode = "";
            ErrorMessage = "";
        }
        #region Property
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

    }
    public interface IProductType
    {
        List<ProductType> Gets(int nBUID, int nUserID);
        List<ProductType> Gets(string sSQL, int nBUID, int nUserID);
        ProductType Get(int nID, int nProductTypeID);
        ProductType IUD(ProductType oProductType, EnumDBOperation eEnumDBAction, int nUserID);
    }
}

