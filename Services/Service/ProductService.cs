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
    public class ProductService : CommonGateway, IProduct
    {
        #region Maping
        private Product MapObject(SqlDataReader oReader)
        {
            Product oProduct = new Product();
            oProduct.ProductID = (int)oReader["ProductID"];
            oProduct.ProductName = oReader["ProductName"].ToString();
            oProduct.ProductCode = oReader["ProductCode"].ToString();
            oProduct.ProductTypeID = (int)oReader["ProductTypeID"];
            oProduct.ProductTypeName = oReader["ProductTypeName"].ToString();
            oProduct.ProductTypeCode = oReader["ProductTypeCode"].ToString();
            oProduct.ProductCategoryID = (int)oReader["ProductCategoryID"];
            oProduct.UnitPrice = Convert.ToDouble(oReader["UnitPrice"]);
            oProduct.CategoryName = oReader["CategoryName"].ToString();
            oProduct.CategoryCode = oReader["CategoryCode"].ToString();
            return oProduct;
        }
        private Product MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            Product oProduct = new Product();
            oProduct = MapObject(oReader);
            return oProduct;
        }
        private List<Product> MakeObjects(SqlDataReader oReader)
        {
            List<Product> oProducts = new List<Product>();
            while (oReader.Read())
            {
                Product oProduct = MapObject(oReader);
                oProducts.Add(oProduct);
            }
            return oProducts;
        }
        #endregion
        #region Function Implementation
        public Product IUD(Product oProduct, int nProductID)
        {
            Connection.Open();
            if (oProduct.ProductID == 0)
            {
                Command.CommandText = ProductDA.IUD(oProduct, EnumDBOperation.Insert, nProductID);
            }
            else
            {
                Command.CommandText = ProductDA.IUD(oProduct, EnumDBOperation.Update, nProductID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            Product _oProduct = new Product();
            if (reader.HasRows)
            {
                _oProduct = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProduct;
        }
        public string Delete(Product oProduct, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = ProductDA.IUD(oProduct, EnumDBOperation.Delete, nUserID);
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
        public List<Product> Gets(int nBUID, int nProduct)
        {
            Connection.Open();
            Command.CommandText = ProductDA.Gets(nBUID, nProduct);

            SqlDataReader reader = Command.ExecuteReader();
            Product _oProduct = new Product();
            List<Product> _oProducts = new List<Product>();
            if (reader.HasRows)
            {
                _oProducts = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProducts;
        }
        public List<Product> GetsProductByTypeAndCategory(string nProductName, int nProductTypeID, int nCategory, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductDA.GetsProductByTypeAndCategory(nProductName, nProductTypeID, nCategory, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            Product _oProduct = new Product();
            List<Product> _oProducts = new List<Product>();
            if (reader.HasRows)
            {
                _oProducts = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProducts;
        }
        public List<Product> Gets(string sSQL, int nBUID, int nProduct)
        {
            Connection.Open();
            Command.CommandText = ProductDA.Gets(sSQL, nBUID, nProduct);

            SqlDataReader reader = Command.ExecuteReader();
            Product _oProduct = new Product();
            List<Product> _oProducts = new List<Product>();
            if (reader.HasRows)
            {
                _oProducts = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProducts;
        }
        public Product Get(int nID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductDA.Get(nID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            Product _oProduct = new Product();
            if (reader.HasRows)
            {
                _oProduct = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProduct;
        }
        #endregion

    }
}
