using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class Bill
    {
        public Bill()
        {
            BillID = 0;
            BillNo = "";
            BillDate = DateTime.Now;
            StoreID = 0;
            DiscountAmount = 0;
            BillStatus = EnumBillStatus.None;
            GrandTotal = 0;
            BillDetails = new List<BillDetail>();
            Remarks = "";
            ErrorMessage = "";
        }
        #region Property
        public int BillID { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public int StoreID { get; set; }
        public double DiscountAmount { get; set; }
        public double GrandTotal { get; set; }
        public double PaidTotal { get; set; }
        public double DueAmount { get; set; }
        public List<BillDetail> BillDetails { get; set; }
        public string Remarks { get; set; }
        public EnumBillStatus BillStatus { get; set; }
        public string ErrorMessage { get; set; }
        public double DiscountPercent { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }


        public string BillNo_Ref { get; set; }
        public int BillID_Ref { get; set; }
        public double AmountToPaid { get; set; }
        public double TotalPaidAmount { get; set; }
        public double YetToPay { get; set; }
        #endregion

        #region Derived Property
        public string BillDateSt
        {
            get
            {
                return this.BillDate.ToString("dd MMM yyyy");
            }
        }
        public string BillDateWithTime
        {
            get
            {
                return this.BillDate.ToString("dd MMM yyyy (hh : mm tt)");
            }
        }
        public string BillStatusSt
        {
            get
            {
                return this.BillStatus.ToString();
            }
        }
        public double PreviousTotal
        {
            get
            {
                return this.DiscountAmount + this.PaidTotal + this.DueAmount;
            }
        }

        #endregion
    }
    public interface IBill
    {
        List<Bill> Gets(int nBUID, int nBill);
        List<Bill> Gets(string sSQL, int nBUID, int nBill);
        Bill Get(int nID, int nBillID);
        Bill IUD(Bill oBill, int nUnserID);
        string Delete(Bill oBill, int nBillID);
    }


}
