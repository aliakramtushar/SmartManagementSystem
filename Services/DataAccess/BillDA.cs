using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class BillDA
    {
        public static string IUD(Bill oBill, EnumDBOperation eDBAction, int userID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_Bill", oBill.BillID, oBill.BillNo, (int)oBill.BillStatus, oBill.BillDate, oBill.CustomerName, oBill.CustomerMobile, oBill.CustomerAddress, oBill.StoreID,
                oBill.PaidTotal, oBill.DiscountAmount,oBill.DiscountPercent, oBill.GrandTotal, oBill.DueAmount, oBill.Remarks, oBill.BillID_Ref, (int)eDBAction, userID);
        }
        public static string Gets(int nBUID, int nBill)
        {
            return "SELECT * FROM View_Bill ORDER BY BillDate DESC";
        }
        public static string Gets(string sSQL, int nBUID, int nBill)
        {
            return sSQL;
        }
        public static string Gets(string sSQL, int nBill)
        {
            return sSQL;
        }
        public static string Get(int nID, int nBillID)
        {
            return "SELECT * FROM View_Bill WHERE [BillID] =" + nID;
        }
    }
}
