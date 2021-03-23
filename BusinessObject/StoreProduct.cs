using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class StoreProduct
    {
        public StoreProduct()
        {
            StoreProductID = 0;
            StoreID = 0;
            ProductID = 0;
            ContractorID = 0;
            ProductQty = 0;
            ProductNewQty = 0;
            Remarks = "";
            ProductName = "";
            ProductCode = "";
            ProductTypeID = 0;
            ProductTypeName = "";
            ProductTypeCode = "";
            ProductCategoryID = 0;
            CategoryCode = "";
            Categoryname = "";
            ContractorName = "";
            UnitPrice = 0;
            StoreDate = DateTime.Now;
            StoreEntryDate = DateTime.Now;
            CustomerName = "";
            Rate = 0;
            ErrorMessage = "";
        }
        #region Property
        public int StoreProductID { get; set; }
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public int ContractorID { get; set; }
        public double ProductQty { get; set; }
        public double ProductNewQty { get; set; }
        public string Remarks { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public int ProductCategoryID { get; set; }
        public string ContractorName { get; set; }
        public string CategoryCode { get; set; }
        public string Categoryname { get; set; }
        public double UnitPrice { get; set; }
        public double Rate { get; set; }
        public DateTime StoreEntryDate { get; set; }
        public DateTime StoreDate { get; set; }
        public string CustomerName { get; set; }
        public string ErrorMessage { get; set; }

        #endregion

        #region Derived Property
        public string StoreDateSt
        {
            get
            {
                return this.StoreDate.ToString("dd MMM yyyy");
            }
        }
        public string StoreEntryDateSt
        {
            get
            {
                return this.StoreEntryDate.ToString("dd MMM yyyy");
            }
        }
        public double TotalPrice
        {
            get
            {
                return Math.Round(this.ProductQty * this.UnitPrice, 2);
            }
        }
        #endregion
    }
    public interface IStoreProduct
    {
        List<StoreProduct> Gets(int nBUID, int nUserID);
        List<StoreProduct> Gets(string sSQL, int nBUID);
        StoreProduct Get(int nStoreID, int nProductID, int nUserID);
        StoreProduct IUD(StoreProduct oStoreProduct, int nUnserID);
        string Delete(StoreProduct oStoreProduct, int nStoreProductID);
    }


}

