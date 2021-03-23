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
    public class StoreService : CommonGateway, IStore
    {
        #region Maping
        private Store MapObject(SqlDataReader oReader)
        {
            Store oStore = new Store();
            oStore.StoreID = (int)oReader["StoreID"];
            oStore.StoreName = oReader["StoreName"].ToString();
            oStore.StoreShortName = oReader["StoreShortName"].ToString();
            oStore.Capacity = Convert.ToDouble(oReader["Capacity"]);
            return oStore;
        }
        private Store MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            Store oStore = new Store();
            oStore = MapObject(oReader);
            return oStore;
        }
        private List<Store> MakeObjects(SqlDataReader oReader)
        {
            List<Store> oStores = new List<Store>();
            while (oReader.Read())
            {
                Store oStore = MapObject(oReader);
                oStores.Add(oStore);
            }
            return oStores;
        }
        #endregion
        #region Function Implementation
        public Store IUD(Store oStore, int nStoreID)
        {
            Connection.Open();
            if (oStore.StoreID == 0)
            {
                Command.CommandText = StoreDA.IUD(oStore, EnumDBOperation.Insert, nStoreID);
            }
            else
            {
                Command.CommandText = StoreDA.IUD(oStore, EnumDBOperation.Update, nStoreID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            Store _oStore = new Store();
            if (reader.HasRows)
            {
                _oStore = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStore;
        }
        public string Delete(Store oStore, int nStoreID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = StoreDA.IUD(oStore, EnumDBOperation.Delete, nStoreID);
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
        public List<Store> Gets(int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreDA.Gets(nBUID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            Store _oStore = new Store();
            List<Store> _oStores = new List<Store>();
            if (reader.HasRows)
            {
                _oStores = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStores;
        }
        public List<Store> Gets(string sSQL, int nBUID, int nStore)
        {
            Connection.Open();
            Command.CommandText = StoreDA.Gets(sSQL, nBUID, nStore);

            SqlDataReader reader = Command.ExecuteReader();
            Store _oStore = new Store();
            List<Store> _oStores = new List<Store>();
            if (reader.HasRows)
            {
                _oStores = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStores;
        }
        public Store Get(int nID, int nStoreID)
        {
            Connection.Open();
            Command.CommandText = StoreDA.Get(nID, nStoreID);

            SqlDataReader reader = Command.ExecuteReader();
            Store _oStore = new Store();
            if (reader.HasRows)
            {
                _oStore = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStore;
        }
        #endregion

    }
}
