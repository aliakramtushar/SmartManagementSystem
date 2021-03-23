using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class BillDetail
    {
        public BillDetail()
        {
            BillDetailID = 0;
            BillID = 0;
            ProductID = 0;
            Quantity = 0;
            Price = 0;
            ProductTypeID = 0;
            ProductTypeName = "";
            ProductTypeCode = "";
            Remarks = "";
            ErrorMessage = "";
        }
        #region Property
        public int BillDetailID { get; set; }
        public int BillID { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string CategoryCode { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Remarks { get; set; }
        
        public string ErrorMessage { get; set; }

        #endregion

        #region Derived Property
        public double Total
        {
            get
            {
                return this.Quantity * this.Price;
            }
        }
        #endregion
    }
    public interface IBillDetail
    {
        List<BillDetail> Gets(string sSQL, int nBUID, int nBillDetail);
        List<BillDetail> GetsByBillID(int nBillID, int nUserID);
        BillDetail Get(int nID, int nBillDetailID);
        BillDetail IUD(BillDetail oBillDetail, int nUnserID);
        string Delete(BillDetail oBillDetail, int nBillDetailID);
    }


}

