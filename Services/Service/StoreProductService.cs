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
    public class StoreProductService : CommonGateway, IStoreProduct
    {
        #region Maping
        private StoreProduct MapObject(SqlDataReader oReader)
        {
            StoreProduct oStoreProduct = new StoreProduct();
            oStoreProduct.StoreProductID = (int)oReader["StoreProductID"];
            oStoreProduct.StoreID = (int)oReader["StoreID"];
            oStoreProduct.ProductID = (int)oReader["ProductID"];
            oStoreProduct.ContractorID = (int)oReader["ContractorID"];
            oStoreProduct.ProductQty = Convert.ToDouble(oReader["ProductQty"]);
            oStoreProduct.Remarks = oReader["Remarks"].ToString();
            oStoreProduct.ProductName = oReader["ProductName"].ToString();
            oStoreProduct.ProductCode = oReader["ProductCode"].ToString();
            oStoreProduct.ProductTypeID = (int)oReader["ProductTypeID"];
            oStoreProduct.ProductTypeName = oReader["ProductTypeName"].ToString();
            oStoreProduct.ProductTypeCode = oReader["ProductTypeCode"].ToString();
            oStoreProduct.ProductCategoryID = (int)oReader["ProductCategoryID"];
            oStoreProduct.CategoryCode = oReader["CategoryCode"].ToString();
            oStoreProduct.Categoryname = oReader["Categoryname"].ToString();
            oStoreProduct.ContractorName = oReader["ContractorName"].ToString();
            oStoreProduct.UnitPrice = Convert.ToDouble(oReader["UnitPrice"]);
            oStoreProduct.StoreDate = Convert.ToDateTime(oReader["LastUpdatedDateTime"]);
            oStoreProduct.StoreEntryDate = Convert.ToDateTime(oReader["DBServerDateTime"]);
            
            return oStoreProduct;
        }
        private StoreProduct MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            StoreProduct oStoreProduct = new StoreProduct();
            oStoreProduct = MapObject(oReader);
            return oStoreProduct;
        }
        private List<StoreProduct> MakeObjects(SqlDataReader oReader)
        {
            List<StoreProduct> oStoreProducts = new List<StoreProduct>();
            while (oReader.Read())
            {
                StoreProduct oStoreProduct = MapObject(oReader);
                oStoreProducts.Add(oStoreProduct);
            }
            return oStoreProducts;
        }
        #endregion

        #region Function Implementation
        public StoreProduct IUD(StoreProduct oStoreProduct, int nUserID)
        {
            Connection.Open();
            if (oStoreProduct.StoreProductID == 0)
            {
                Command.CommandText = StoreProductDA.IUD(oStoreProduct, EnumDBOperation.Insert, nUserID);
            }
            else
            {
                Command.CommandText = StoreProductDA.IUD(oStoreProduct, EnumDBOperation.Update, nUserID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            StoreProduct _oStoreProduct = new StoreProduct();
            if (reader.HasRows)
            {
                _oStoreProduct = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProduct;
        }
        public StoreProduct SellProduct(StoreProduct oStoreProduct, int nUserID)
        {
            Connection.Open();
            if (oStoreProduct.StoreProductID > 0)
            {
                Command.CommandText = StoreProductDA.IUD(oStoreProduct, EnumDBOperation.Custom_1, nUserID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            StoreProduct _oStoreProduct = new StoreProduct();
            if (reader.HasRows)
            {
                _oStoreProduct = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProduct;
        }
        public string Delete(StoreProduct oStoreProduct, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = StoreProductDA.IUD(oStoreProduct, EnumDBOperation.Delete, nUserID);
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
        public List<StoreProduct> Gets(int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductDA.Gets(nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProduct _oStoreProduct = new StoreProduct();
            List<StoreProduct> _oStoreProducts = new List<StoreProduct>();
            if (reader.HasRows)
            {
                _oStoreProducts = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProducts;
        }
        public List<StoreProduct> Gets(string sSQL, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductDA.Gets(sSQL, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProduct _oStoreProduct = new StoreProduct();
            List<StoreProduct> _oStoreProducts = new List<StoreProduct>();
            if (reader.HasRows)
            {
                _oStoreProducts = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProducts;
        }
        public List<StoreProduct> GetsByStoreID(int nStoreID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductDA.GetsByStoreID(nStoreID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProduct _oStoreProduct = new StoreProduct();
            List<StoreProduct> _oStoreProducts = new List<StoreProduct>();
            if (reader.HasRows)
            {
                _oStoreProducts = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProducts;
        }
        public StoreProduct Get(int nStoreID, int nProductID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = StoreProductDA.Get(nStoreID, nProductID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            StoreProduct _oStoreProduct = new StoreProduct();
            if (reader.HasRows)
            {
                _oStoreProduct = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oStoreProduct;
        }
        #endregion

    }
}




