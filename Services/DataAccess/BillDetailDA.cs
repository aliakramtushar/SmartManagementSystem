using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class BillDetailDA
    {
        public static string IUD(BillDetail oBillDetail, EnumDBOperation eDBAction, int userID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_BillDetail", oBillDetail.BillDetailID, oBillDetail.BillID,
                oBillDetail.ProductName, oBillDetail.Price, oBillDetail.Quantity, (int)eDBAction, userID);
        }
        public static string Gets(int nBUID, int nBillDetail)
        {
            return "SELECT * FROM View_BillDetail";
        }
        public static string GetsByBillID(int nBUID, int nBillDetail)
        {
            return "SELECT * FROM View_BillDetail WHERE BillID = " + nBUID;
        }
        public static string Gets(string sSQL, int nBillDetail)
        {
            return sSQL;
        }
        public static string Get(int nID, int nBillDetailID)
        {
            return "SELECT * FROM View_BillDetail WHERE [BillDetailID] =" + nID;
        }
    }
}
