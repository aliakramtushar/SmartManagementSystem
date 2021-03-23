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
    public class ProductTypeService : CommonGateway, IProductType
    {
        #region Maping


        #endregion
        private ProductType MapObject(SqlDataReader oReader)
        {
            ProductType oProductType = new ProductType();
            oProductType.ProductTypeID = (int)oReader["ProductTypeID"];
            oProductType.ProductTypeName = oReader["ProductTypeName"].ToString();
            oProductType.ProductTypeCode = oReader["ProductTypeCode"].ToString();
            return oProductType;
        }
        private ProductType MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            ProductType oProductType = new ProductType();
            oProductType = MapObject(oReader);
            return oProductType;
        }
        private List<ProductType> MakeObjects(SqlDataReader oReader)
        {
            List<ProductType> oProductTypes = new List<ProductType>();
            while (oReader.Read())
            {
                ProductType oProductType = MapObject(oReader);
                oProductTypes.Add(oProductType);
            }
            return oProductTypes;
        }

        #region Function Implementation

        public List<ProductType> Gets(int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductTypeDA.Gets(nBUID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductType _oProductType = new ProductType();
            List<ProductType> _oProductTypes = new List<ProductType>();
            if (reader.HasRows)
            {
                _oProductTypes = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductTypes;
        }
        public List<ProductType> Gets(string sSQL, int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductTypeDA.Gets(sSQL, nBUID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductType _oProductType = new ProductType();
            List<ProductType> _oProductTypes = new List<ProductType>();
            if (reader.HasRows)
            {
                _oProductTypes = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductTypes;
        }
        public ProductType Get(int nProductTypeID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductTypeDA.Get(nProductTypeID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductType _oProductType = new ProductType();
            if (reader.HasRows)
            {
                _oProductType = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductType;
        }
        public ProductType IUD(ProductType oProductType, EnumDBOperation eDBAction, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductTypeDA.IUD(oProductType, eDBAction, nUserID);

            SqlDataReader reader = Command.ExecuteReader();

            ProductType _oProductType = new ProductType();
            if (reader.HasRows)
            {
                _oProductType = MakeObject(reader);
            }
            reader.Close();

            Connection.Close();
            return _oProductType;
        }
        public string Delete(ProductType oProductType, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = ProductTypeDA.IUD(oProductType, EnumDBOperation.Delete, nUserID);
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
        #endregion
    }
}

