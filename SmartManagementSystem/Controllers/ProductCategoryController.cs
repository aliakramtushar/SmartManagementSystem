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
    public class ProductCategoryController : Controller
    {
        ProductCategory _oProductCategory = new ProductCategory();
        List<ProductCategory> _oProductCategorys = new List<ProductCategory>() { };
        ProductCategoryService _oProductCategoryService = new ProductCategoryService();
        ProductType _oProductType = new ProductType();
        List<ProductType> _oProductTypes = new List<ProductType>();
        ProductTypeService _oProductTypeService = new ProductTypeService();

        public ActionResult ViewProductCategorys(int nBUID, int menuid)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oProductCategorys = _oProductCategoryService.Gets(nBUID, (int)Session[GlobalSession.UserID]);
            return View(_oProductCategorys);
        }
        public ActionResult ViewProductCategory(int nProductCategoryID)
        {
            GlobalSession.SessionIsAlive(Session, Response);

            ProductCategory _oProductCategory = new ProductCategory();
            if (nProductCategoryID > 0)
            {
                _oProductCategory = _oProductCategoryService.Get(nProductCategoryID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            return View(_oProductCategory);
        }
        public ActionResult Save(ProductCategory oProductCategory)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            if (oProductCategory.ProductCategoryID <= 0)
            {
                _oProductCategory = _oProductCategoryService.IUD(oProductCategory, EnumDBOperation.Insert, (int)Session[GlobalSession.UserID]);
            }
            else
            {
                _oProductCategory = _oProductCategoryService.IUD(oProductCategory, EnumDBOperation.Update, (int)Session[GlobalSession.UserID]);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProductCategory);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(ProductCategory oProductCategory)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            
            ProductCategory _oProductCategory = new ProductCategory();
            if (oProductCategory.ProductCategoryID > 0)
            {
                _oProductCategory = _oProductCategoryService.IUD(oProductCategory, EnumDBOperation.Delete, (int)Session[GlobalSession.UserID]);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProductCategory);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(ProductCategory oProductCategory)
        {
            _oProductCategorys = _oProductCategoryService.Gets("SELECT * FROM View_ProductCategory WHERE CategoryName LIKE '%" + oProductCategory.CategoryName + "%' OR CategoryCode Like '%" + oProductCategory.CategoryName + "%'", 1, (int)Session[GlobalSession.UserID]);
            if (_oProductCategorys.Count <= 0)
            {
                _oProductCategorys = new List<ProductCategory>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProductCategorys);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}