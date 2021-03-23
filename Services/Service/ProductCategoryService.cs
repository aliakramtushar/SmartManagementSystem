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
    public class ProductCategoryService : CommonGateway, IProductCategory
    {
        #region Maping


        #endregion
        private ProductCategory MapObject(SqlDataReader oReader)
        {
            ProductCategory oProductCategory = new ProductCategory();
            oProductCategory.ProductCategoryID = (int)oReader["ProductCategoryID"];
            oProductCategory.CategoryName = oReader["CategoryName"].ToString();
            oProductCategory.ProductTypeID = (int)oReader["ProductTypeID"];
            oProductCategory.ProductTypeName = oReader["ProductTypeName"].ToString();
            oProductCategory.ProductTypeCode = oReader["ProductTypeCode"].ToString();
            oProductCategory.CategoryCode = oReader["CategoryCode"].ToString();
            oProductCategory.Note = oReader["Note"].ToString();
            oProductCategory.Activity = Convert.ToBoolean(oReader["Activity"]);
            return oProductCategory;
        }
        private ProductCategory MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            ProductCategory oProductCategory = new ProductCategory();
            oProductCategory = MapObject(oReader);
            return oProductCategory;
        }
        private List<ProductCategory> MakeObjects(SqlDataReader oReader)
        {
            List<ProductCategory> oProductCategorys = new List<ProductCategory>();
            while (oReader.Read())
            {
                ProductCategory oProductCategory = MapObject(oReader);
                oProductCategorys.Add(oProductCategory);
            }
            return oProductCategorys;
        }

        #region Function Implementation

        public List<ProductCategory> Gets(int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductCategoryDA.Gets(nBUID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductCategory _oProductCategory = new ProductCategory();
            List<ProductCategory> _oProductCategorys = new List<ProductCategory>();
            if (reader.HasRows)
            {
                _oProductCategorys = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductCategorys;
        }
        public List<ProductCategory> Gets(string sSQL, int nBUID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductCategoryDA.Gets(sSQL, nBUID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductCategory _oProductCategory = new ProductCategory();
            List<ProductCategory> _oProductCategorys = new List<ProductCategory>();
            if (reader.HasRows)
            {
                _oProductCategorys = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductCategorys;
        }
        public List<ProductCategory> GetsByProductType(int nProductType, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductCategoryDA.GetsByProductType(nProductType, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductCategory _oProductCategory = new ProductCategory();
            List<ProductCategory> _oProductCategorys = new List<ProductCategory>();
            if (reader.HasRows)
            {
                _oProductCategorys = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductCategorys;
        }
        public ProductCategory Get(int nProductCategoryID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ProductCategoryDA.Get(nProductCategoryID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ProductCategory _oProductCategory = new ProductCategory();
            if (reader.HasRows)
            {
                _oProductCategory = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oProductCategory;
        }
        public ProductCategory IUD(ProductCategory oProductCategory, EnumDBOperation eDBAction, int userid)
        {
            Connection.Open();
            Command.CommandText = ProductCategoryDA.IUD(oProductCategory, eDBAction, userid);

            SqlDataReader reader = Command.ExecuteReader();
            
            ProductCategory _oProductCategory = new ProductCategory();
            if (reader.HasRows)
            {
                _oProductCategory = MakeObject(reader);
            }
            reader.Close();

            Connection.Close();
            return _oProductCategory;
        }
        #endregion
    }
}
