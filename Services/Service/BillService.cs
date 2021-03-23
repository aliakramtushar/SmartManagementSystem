using System;
using BusinessObject;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.DataBaseGateway;
using Services.DataAccess;
using System.Data.SqlClient;
using SMSEngine.GlobalClass;

namespace Services.Service
{
    public class BillService : CommonGateway, IBill
    {
        #region Maping
        private Bill MapObject(SqlDataReader oReader)
        {
            Bill oBill = new Bill();
            oBill.BillID = (int)oReader["BillID"];
            oBill.BillNo = oReader["BillNo"].ToString();
            oBill.StoreID = (int)oReader["StoreID"];
            oBill.BillDate = Convert.ToDateTime(oReader["BillDate"]);
            oBill.PaidTotal = Convert.ToDouble(oReader["PaidTotal"]);
            oBill.DiscountAmount = Convert.ToDouble(oReader["DiscountAmount"]);
            oBill.DueAmount = Math.Round(Convert.ToDouble(oReader["DueAmount"]), 2);
            oBill.GrandTotal = Math.Round(Convert.ToDouble(oReader["GrandTotal"]), 2);
            oBill.CustomerName = oReader["CustomerName"].ToString();
            oBill.CustomerMobile = oReader["CustomerMobile"].ToString();
            oBill.CustomerAddress = oReader["CustomerAddress"].ToString();
            oBill.BillID_Ref = (int)oReader["BillID_Ref"];
            oBill.BillNo_Ref = oReader["BillNo_Ref"].ToString();
            oBill.AmountToPaid = Math.Round(Convert.ToDouble(oReader["AmountToPaid"]), 2);
            oBill.TotalPaidAmount = Math.Round(Convert.ToDouble(oReader["TotalPaidAmount"]), 2); 
            //oBill.YetToPay = Convert.ToDouble(oReader["YetToPay"]);
            
            return oBill;
        }
        private Bill MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            Bill oBill = new Bill();
            oBill = MapObject(oReader);
            return oBill;
        }
        private List<Bill> MakeObjects(SqlDataReader oReader)
        {
            List<Bill> oBills = new List<Bill>();
            while (oReader.Read())
            {
                Bill oBill = MapObject(oReader);
                oBills.Add(oBill);
            }
            return oBills;
        }
        #endregion

        #region Function Implementation
        public Bill IUD(Bill oBill, int nUserID)
        {
            Connection.Open();
            if (oBill.BillID == 0)
            {
                Command.CommandText = BillDA.IUD(oBill, EnumDBOperation.Insert, nUserID);
            }
            else
            {
                Command.CommandText = BillDA.IUD(oBill, EnumDBOperation.Update, nUserID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            Bill _oBill = new Bill();
            if (reader.HasRows)
            {
                _oBill = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBill;
        }
        public string Delete(Bill oBill, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = BillDA.IUD(oBill, EnumDBOperation.Delete, nUserID);
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                sReturnMessage = e.Message.Split('~')[0];
            }
            Connection.Close();
            return sReturnMessage;
        }
        public List<Bill> Gets(int nBUID, int nBill)
        {
            Connection.Open();
            Command.CommandText = BillDA.Gets(nBUID, nBill);

            SqlDataReader reader = Command.ExecuteReader();
            Bill _oBill = new Bill();
            List<Bill> _oBills = new List<Bill>();
            if (reader.HasRows)
            {
                _oBills = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBills;
        }
        public List<Bill> Gets(string sSQL, int nBUID, int nBill)
        {
            Connection.Open();
            Command.CommandText = BillDA.Gets(sSQL, nBUID, nBill);

            SqlDataReader reader = Command.ExecuteReader();
            Bill _oBill = new Bill();
            List<Bill> _oBills = new List<Bill>();
            if (reader.HasRows)
            {
                _oBills = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBills;
        }
        public Bill Get(int nID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = BillDA.Get(nID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            Bill _oBill = new Bill();
            if (reader.HasRows)
            {
                _oBill = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBill;
        }
        #endregion
    }
}
