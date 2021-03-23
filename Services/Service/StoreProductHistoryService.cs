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
    public class StoreProductHistoryService : CommonGateway, IStoreProductHistory
    {
        #region Maping
        private StoreProductHistory MapObject(SqlDataReader oReader)
        {
            StoreProductHistory oStoreProductHistory = new StoreProductHistory();
            oStoreProductHistory.StoreProductHistoryID = (int)oReader["StoreProductHistoryID"];
            oStoreProductHistory.Operation = (EnumDBOperation)oReader["OperationID"];
            oStoreProductHistory.ActionDate = Convert.ToDateTime(oReader["DBServerDateTime"]);
            oStoreProductHistory.StoreID = (int)oReader["StoreID"];
            oStoreProductHistory.StoreName = oReader["StoreName"].ToString();
            oStoreProductHistory.ProductTypeID = (int)oReader["ProductTypeID"];
            oStoreProductHistory.ProductTypeName = oReader["ProductTypeName"].ToString();
            oStoreProductHistory.ProductTypeCode = oReader["ProductTypeCode"].ToString();
            oStoreProductHistory.ProductCategoryID = (int)oReader["ProductCategoryID"];
            oStoreProductHistory.ProductCategoryName = oReader["CategoryName"].ToString();
            oStoreProductHistory.ProductID = (int)oReader["ProductID"];
            oStoreProductHistory.ProductName = oReader["ProductName"].ToString();
            oStoreProductHistory.ProductCode = oReader["ProductCode"].ToString();
            oStoreProductHistory.ProductOldQty = Convert.ToDouble(oReader["ProductOldQty"]);
            oStoreProductHistory.ProductNewQty = Convert.ToDouble(oReader["ProductNewQty"]);
            oStoreProductHistory.UnitPrice = Convert.ToDouble(oReader["UnitPrice"]);
            oStoreProductHistory.ContractorID = (int)oReader["ContractorID"];
            oStoreProductHistory.CustomerName = oReader["CustomerName"].ToString();
            oStoreProductHistory.Remarks = oReader["Remarks"].ToString();
            oStoreProductHistory.UserID = (int)oReader["UserID"];
            oStoreProductHistory.Rate = Convert.ToDouble(oReader["Rate"]);
            oStoreProductHistory.UserName = oReader["UserName"].ToString();

            return oStoreProductHistory;
        }
        private StoreProductHistory MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            StoreProductHistory oStoreProductHistory = new StoreProductHistory();
            oStoreProductHistory = MapObject(oReader);
            return oStoreProductHistory;
        }
        private List<StoreProductHistory> MakeObjects(SqlDataReader oReader)
        {
            List<StoreProductHistory> oStoreProductHistorys = new List<StoreProductHistory>();
            while (oReader.Read())
            {
                StoreProductHistory oStoreProductHistory = MapObject(oReader);
                oStoreProductHistorys.Add(oStoreProductHistory);
            }
            return oStoreProductHistorys;
        }
        #endregion

        #region Function Implementation
        public string Delete(StoreProductHistory oStoreProductHistory, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = StoreProductHistoryDA.IUD(oStoreProductHistory, EnumDBOperation.Delete, nUserID);
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
        public List<StoreProductHistory> Gets(int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductHistoryDA.Gets(nBUID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProductHistory _oStoreProductHistory = new StoreProductHistory();
            List<StoreProductHistory> _oStoreProductHistorys = new List<StoreProductHistory>();
            if (reader.HasRows)
            {
                _oStoreProductHistorys = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProductHistorys;
        }
        public List<StoreProductHistory> Gets(string sSQL, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductHistoryDA.Gets(sSQL, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProductHistory _oStoreProductHistory = new StoreProductHistory();
            List<StoreProductHistory> _oStoreProductHistorys = new List<StoreProductHistory>();
            if (reader.HasRows)
            {
                _oStoreProductHistorys = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProductHistorys;
        }
        public StoreProductHistory Get(int nID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductHistoryDA.Get(nID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProductHistory _oStoreProductHistory = new StoreProductHistory();
            if (reader.HasRows)
            {
                _oStoreProductHistory = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProductHistory;
        }
        #endregion

    }
}





