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
    public class BillDetailService : CommonGateway, IBillDetail
    {
        #region Maping
        private BillDetail MapObject(SqlDataReader oReader)
        {
            BillDetail oBillDetail = new BillDetail();
            oBillDetail.BillDetailID = (int)oReader["BillDetailID"];
            oBillDetail.BillID = (int)oReader["BillID"];
            oBillDetail.ProductName = oReader["ProductName"].ToString();
            oBillDetail.Price = Convert.ToDouble(oReader["Price"]);
            oBillDetail.Quantity = Convert.ToDouble(oReader["Quantity"]);

            return oBillDetail;
        }
        private BillDetail MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            BillDetail oBillDetail = new BillDetail();
            oBillDetail = MapObject(oReader);
            return oBillDetail;
        }
        private List<BillDetail> MakeObjects(SqlDataReader oReader)
        {
            List<BillDetail> oBillDetails = new List<BillDetail>();
            while (oReader.Read())
            {
                BillDetail oBillDetail = MapObject(oReader);
                oBillDetails.Add(oBillDetail);
            }
            return oBillDetails;
        }
        #endregion

        #region Function Implementation
        public BillDetail IUD(BillDetail oBillDetail, int nUserID)
        {
            Connection.Open();
            if (oBillDetail.BillDetailID == 0)
            {
                Command.CommandText = BillDetailDA.IUD(oBillDetail, EnumDBOperation.Insert, nUserID);
            }
            else
            {
                Command.CommandText = BillDetailDA.IUD(oBillDetail, EnumDBOperation.Update, nUserID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            BillDetail _oBillDetail = new BillDetail();
            if (reader.HasRows)
            {
                _oBillDetail = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBillDetail;
        }
        public string Delete(BillDetail oBillDetail, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = BillDetailDA.IUD(oBillDetail, EnumDBOperation.Delete, nUserID);
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
        public List<BillDetail> Gets(int nBUID, int nBillDetail)
        {
            Connection.Open();
            Command.CommandText = BillDetailDA.Gets(nBUID, nBillDetail);

            SqlDataReader reader = Command.ExecuteReader();
            BillDetail _oBillDetail = new BillDetail();
            List<BillDetail> _oBillDetails = new List<BillDetail>();
            if (reader.HasRows)
            {
                _oBillDetails = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBillDetails;
        }
        public List<BillDetail> GetsByBillID(int nBillID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = BillDetailDA.GetsByBillID(nBillID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            BillDetail _oBillDetail = new BillDetail();
            List<BillDetail> _oBillDetails = new List<BillDetail>();
            if (reader.HasRows)
            {
                _oBillDetails = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBillDetails;
        }
        public List<BillDetail> Gets(string sSQL, int nBUID, int nBillDetail)
        {
            Connection.Open();
            Command.CommandText = BillDetailDA.Gets(sSQL, nBillDetail);

            SqlDataReader reader = Command.ExecuteReader();
            BillDetail _oBillDetail = new BillDetail();
            List<BillDetail> _oBillDetails = new List<BillDetail>();
            if (reader.HasRows)
            {
                _oBillDetails = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBillDetails;
        }
        public BillDetail Get(int nID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = BillDetailDA.Get(nID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            BillDetail _oBillDetail = new BillDetail();
            if (reader.HasRows)
            {
                _oBillDetail = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oBillDetail;
        }
        #endregion

    }
}
