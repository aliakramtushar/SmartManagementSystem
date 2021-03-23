using BusinessObject;
using SMSEngine;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSEngine.GlobalClass;
using System.Web.Script.Serialization;

namespace SmartManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Product _oProduct = new Product();
        List<Product> _oProducts = new List<Product>() { };
        ProductService _oProductService = new ProductService();
        ProductType _oProductType = new ProductType();
        List<ProductType> _oProductTypes = new List<ProductType>();
        ProductTypeService _oProductTypeService = new ProductTypeService();
        ProductCategoryService _oProductCategoryService = new ProductCategoryService();
        public ActionResult ViewProducts(int nBUID, int nUserID)
        {
            _oProducts = _oProductService.Gets(nBUID, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oProducts);
        }
        public ActionResult ViewProduct(int nProductID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Product _oProduct = new Product();
            if (nProductID > 0)
            {
                _oProduct = _oProductService.Get(nProductID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            ViewBag.ProductCategorys = _oProductCategoryService.Gets(1, (int)Session[GlobalSession.UserID]);
            return View(_oProduct);
        }
        [HttpPost]
        public JsonResult IUD(Product oProduct)
        {
            _oProduct = new Product();
            ProductService oProductService = new ProductService();
            try
            {
                _oProduct = oProduct;
                _oProduct = oProductService.IUD(oProduct, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oProduct = new Product();
                _oProduct.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProduct);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetsProductByTypeAndCategory(Product oProduct)
        {
            _oProduct = new Product();
            _oProducts = new List<Product>();
            ProductService oProductService = new ProductService();
            try
            {
                _oProducts = oProductService.GetsProductByTypeAndCategory(oProduct.ProductName, oProduct.ProductTypeID, oProduct.ProductCategoryID, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oProduct = new Product();
                _oProduct.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProducts);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetProductCategory(Product oProduct)
        {
            List<ProductCategory> oProductCategorys = new List<ProductCategory>();
            ProductCategoryService oProductCategoryService = new ProductCategoryService();

            try
            {
                if(oProduct.ProductTypeID>0)
                {
                    oProductCategorys = oProductCategoryService.GetsByProductType((int)oProduct.ProductTypeID, (int)Session[GlobalSession.UserID]);
                }
               
            }
            catch (Exception ex)
            {
                ProductCategory oProductCategory = new ProductCategory();
                oProductCategory.ErrorMessage = ex.Message;
                oProductCategorys.Add(oProductCategory);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(oProductCategorys);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(Product oProduct)
        {
            _oProduct = new Product();
            ProductService oProductService = new ProductService();
            try
            {
                _oProduct = oProduct;
                _oProduct.ErrorMessage = oProductService.Delete(oProduct, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oProduct = new Product();
                _oProduct.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProduct);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(Product oProduct)
        {
            _oProducts = _oProductService.Gets("SELECT * FROM View_Product WHERE ProductName LIKE '%" + oProduct.ProductName + "%' OR ProductCode LIKE '%" + oProduct.ProductName + "%' ORDER BY ProductName", 1, (int)Session[GlobalSession.UserID]);
            if (_oProducts.Count <= 0)
            {
                _oProducts = new List<Product>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProducts);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}