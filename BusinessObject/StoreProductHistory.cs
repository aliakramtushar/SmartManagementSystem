using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class StoreProductHistory
    {
        public StoreProductHistory()
        {
            StoreProductHistoryID = 0;
            Operation = EnumDBOperation.None;
            StoreID = 0;
            ContractorID = 0;
            ProductID = 0;
            ProductOldQty = 0;
            ProductNewQty = 0;
            Remarks = "";
            ProductName = "";
            ProductCode = "";
            ProductTypeID = 0;
            ProductTypeName = "";
            ProductTypeCode = "";
            ProductCategoryID = 0;
            ContractorName = "";
            ContractorType = EnumContractorType.None;
            UnitPrice = 0;
            ActionDate = DateTime.Now;
            CustomerName = "";
            Rate = 0;
            ErrorMessage = "";
        }
        #region Property
        public int StoreProductHistoryID { get; set; }
        public EnumDBOperation Operation { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public int ContractorID { get; set; }
        public int ProductID { get; set; }
        public double ProductOldQty { get; set; }
        public double ProductNewQty { get; set; }
        public string Remarks { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public string ContractorName { get; set; }
        public EnumContractorType ContractorType { get; set; }
        public double UnitPrice { get; set; }
        public DateTime ActionDate { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public double ProductQty { get; set; }
        public string CustomerName { get; set; }
        public double Rate { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property
        public string ContractorTypeSt
        {
            get
            {
                return this.ContractorType.ToString();
            }
        }
        public double TotalPrice
        {
            get
            {
                return this.ProductNewQty * this.UnitPrice;
            }
        }
        public double NewTotalQty
        {
            get
            {
                if(Operation == EnumDBOperation.Update || Operation == EnumDBOperation.Insert)
                {
                    return ProductOldQty + ProductNewQty;
                }
                else
                {
                    return ProductOldQty - ProductNewQty;
                }
            }
        }
        public string ActionDateSt
        {
            get
            {
                return this.ActionDate.ToString("dd MMM yyyy");
            }
        }
        public string OperationName
        {
            get
            {
                if (Operation == EnumDBOperation.Custom_1)
                {
                    return "Sell Product";
                }
                if (Operation == EnumDBOperation.Insert)
                {
                    return "Add Into Store";
                }
                else
                {
                    return "Quantity Added";
                }
            }
        }
        #endregion
    }
    public interface IStoreProductHistory
    {
        List<StoreProductHistory> Gets(int nBUID, int nUserID);
        List<StoreProductHistory> Gets(string sSQL, int nBUID);
        StoreProductHistory Get(int nID, int nStoreProductHistoryID);
        string Delete(StoreProductHistory oStoreProductHistory, int nStoreProductHistoryID);
    }


}


