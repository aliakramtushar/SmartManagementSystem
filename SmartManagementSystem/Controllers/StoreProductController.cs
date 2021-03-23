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
    public class StoreProductController : Controller
    {
        StoreProduct _oStoreProduct = new StoreProduct();
        List<StoreProduct> _oStoreProducts = new List<StoreProduct>() { };
        StoreProductService _oStoreProductService = new StoreProductService();
        Store _oStore = new Store();
        StoreService _oStoreService = new StoreService();
        List<Store> _oStores = new List<Store>();
        ProductType _oProductType = new ProductType();
        List<ProductType> _oProductTypes = new List<ProductType>();
        ProductTypeService _oProductTypeService = new ProductTypeService();


        public ActionResult ViewStoreProducts(int nBUID, int nUserID)
        {
            GlobalSession.SessionIsAlive(Session, Response);

            _oStores = _oStoreService.Gets(nBUID, (int)Session[GlobalSession.UserID]);

            _oStoreProducts = _oStoreProductService.Gets(nBUID, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oStores);
        }
        public ActionResult ViewStoreProduct(int nStoreID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oStoreProduct = new StoreProduct();

            ContractorService oContractorService = new ContractorService();
            List<Contractor> oContractors = new List<Contractor>();
            oContractors = oContractorService.GetsByContractorType(EnumContractorType.Supplier, (int)Session[GlobalSession.UserID]);


            if (nStoreID > 0)
            {
                _oStore = _oStoreService.Get(nStoreID, (int)Session[GlobalSession.UserID]);
                _oStoreProducts = _oStoreProductService.GetsByStoreID(_oStore.StoreID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            ViewBag.StoreProducts = _oStoreProducts;
            ViewBag.Contractors = oContractors;
            return View(_oStore);
        }
        public ActionResult ViewAddProductQty(int nStoreID, int nStoreProductID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oStoreProduct = new StoreProduct();
            _oStoreProduct.StoreID = nStoreID;

            if (nStoreProductID > 0)
            {
                _oStoreProduct = _oStoreProductService.Get(nStoreID, nStoreProductID, (int)Session[GlobalSession.UserID]);
            }
            ContractorService oContractorService = new ContractorService();
            List<Contractor> oContractors = new List<Contractor>();
            oContractors = oContractorService.GetsByContractorType(EnumContractorType.Supplier, (int)Session[GlobalSession.UserID]);

            List<ProductCategory> oProductCategorys = new List<ProductCategory>();
            ProductCategoryService oProductCategoryService = new ProductCategoryService();
            oProductCategorys = oProductCategoryService.Gets(1, (int)Session[GlobalSession.UserID]);

            List<Product> oProducts = new List<Product>();
            ProductService oProductService = new ProductService();
            oProducts = oProductService.Gets(1, (int)Session[GlobalSession.UserID]);

            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            ViewBag.Contractors = oContractors;
            ViewBag.Products = oProducts;
            ViewBag.ProductCategorys = oProductCategorys;

            return View(_oStoreProduct);
        }
        public ActionResult ViewSellProductQty(int nStoreID, int nStoreProductID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oStoreProduct = new StoreProduct();
            _oStoreProduct.StoreID = nStoreID;

            if (nStoreProductID > 0)
            {
                _oStoreProduct = _oStoreProductService.Get(nStoreID, nStoreProductID, (int)Session[GlobalSession.UserID]);
            }
            ContractorService oContractorService = new ContractorService();
            List<Contractor> oContractors = new List<Contractor>();
            oContractors = oContractorService.GetsByContractorType(EnumContractorType.Supplier, (int)Session[GlobalSession.UserID]);

            List<ProductCategory> oProductCategorys = new List<ProductCategory>();
            ProductCategoryService oProductCategoryService = new ProductCategoryService();
            oProductCategorys = oProductCategoryService.Gets(1, (int)Session[GlobalSession.UserID]);

            List<Product> oProducts = new List<Product>();
            ProductService oProductService = new ProductService();
            oProducts = oProductService.Gets(1, (int)Session[GlobalSession.UserID]);

            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            ViewBag.Contractors = oContractors;
            ViewBag.Products = oProducts;
            ViewBag.ProductCategorys = oProductCategorys;

            return View(_oStoreProduct);
        }
        public ActionResult ViewAddProducts(int nStoreID, int nStoreProductID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oStoreProduct = new StoreProduct();
            _oStoreProduct.StoreID = nStoreID;

            if (nStoreProductID>0)
            {
                _oStoreProduct = _oStoreProductService.Get(nStoreProductID, 0 , (int)Session[GlobalSession.UserID]);
            }
            ContractorService oContractorService = new ContractorService();
            List<Contractor> oContractors = new List<Contractor>();
            oContractors = oContractorService.GetsByContractorType(EnumContractorType.Supplier, (int)Session[GlobalSession.UserID]);

            List<ProductCategory> oProductCategorys = new List<ProductCategory>();
            ProductCategoryService oProductCategoryService = new ProductCategoryService();
            oProductCategorys = oProductCategoryService.Gets(1, (int)Session[GlobalSession.UserID]);

            List<Product> oProducts = new List<Product>();
            ProductService oProductService = new ProductService();
            oProducts = oProductService.Gets(1, (int)Session[GlobalSession.UserID]);

            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            ViewBag.Contractors = oContractors;
            ViewBag.Products = oProducts;
            ViewBag.ProductCategorys = oProductCategorys;

            return View(_oStoreProduct);
        }
        [HttpPost]
        public JsonResult IUD(StoreProduct oStoreProduct)
        {
            _oStoreProduct = new StoreProduct();
            StoreProductService oStoreProductService = new StoreProductService();
            try
            {
                _oStoreProduct = oStoreProductService.IUD(oStoreProduct, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oStoreProduct = new StoreProduct();
                _oStoreProduct.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStoreProduct);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(StoreProduct oStoreProduct)
        {
            _oStoreProduct = new StoreProduct();
            StoreProductService oStoreProductService = new StoreProductService();
            try
            {
                _oStoreProduct = oStoreProduct;
                _oStoreProduct.ErrorMessage = oStoreProductService.Delete(oStoreProduct, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oStoreProduct = new StoreProduct();
                _oStoreProduct.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStoreProduct);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SellProduct(StoreProduct oStoreProduct)
        {
            _oStoreProduct = new StoreProduct();
            StoreProductService oStoreProductService = new StoreProductService();
            try
            {
                _oStoreProduct = oStoreProductService.SellProduct(oStoreProduct, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oStoreProduct = new StoreProduct();
                _oStoreProduct.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStoreProduct);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetByStoreID(StoreProduct oStoreProduct)
        {
            _oStoreProducts = _oStoreProductService.Gets("SELECT * FROM View_StoreProduct WHERE StoreID = " + oStoreProduct.StoreID + " Order By ProductName", (int)Session[GlobalSession.UserID]);
            if (_oStoreProducts.Count <= 0)
            {
                _oStoreProducts = new List<StoreProduct>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStoreProducts);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(StoreProduct oStoreProduct)
        {
            _oStoreProducts = _oStoreProductService.Gets("SELECT* FROM View_StoreProduct WHERE StoreID = "+ oStoreProduct.StoreID + " AND(ProductName LIKE '%"+ oStoreProduct.ProductName + "%' OR ProductCode LIKE '%" + oStoreProduct.ProductName + "%') ORDER BY ProductName", (int)Session[GlobalSession.UserID]);
            if (_oStoreProducts.Count <= 0)
            {
                _oStoreProducts = new List<StoreProduct>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStoreProducts);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }








        

    }
}