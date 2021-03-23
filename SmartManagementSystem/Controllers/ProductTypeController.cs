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
    public class ProductTypeController : Controller
    {
        ProductType _oProductType = new ProductType();
        List<ProductType> _oProductTypes = new List<ProductType>() { };
        ProductTypeService _oProductTypeService = new ProductTypeService();

        public ActionResult ViewProductTypes(int nBUID, int menuid)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oProductTypes = _oProductTypeService.Gets(nBUID, (int)Session[GlobalSession.UserID]);
            return View(_oProductTypes);
        }
        public ActionResult ViewProductType(int nProductTypeID)
        {
            GlobalSession.SessionIsAlive(Session, Response);

            ProductType _oProductType = new ProductType();
            if (nProductTypeID > 0)
            {
                _oProductType = _oProductTypeService.Get(nProductTypeID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ProductTypes = _oProductTypeService.Gets(1, (int)Session[GlobalSession.UserID]);
            return View(_oProductType);
        }
        public ActionResult Save(ProductType oProductType)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            if (oProductType.ProductTypeID <= 0)
            {
                _oProductType = _oProductTypeService.IUD(oProductType, EnumDBOperation.Insert, (int)Session[GlobalSession.UserID]);
            }
            else
            {
                _oProductType = _oProductTypeService.IUD(oProductType, EnumDBOperation.Update, (int)Session[GlobalSession.UserID]);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProductType);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(ProductType oProductType)
        {
            GlobalSession.SessionIsAlive(Session, Response);

            ProductType _oProductType = new ProductType();
            if (oProductType.ProductTypeID > 0)
            {
                _oProductType.ErrorMessage = _oProductTypeService.Delete(oProductType, (int)Session[GlobalSession.UserID]);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProductType);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(ProductType oProductType)
        {
            _oProductTypes = _oProductTypeService.Gets("SELECT * FROM ProductType WHERE ProductTypeName LIKE '%" + oProductType.ProductTypeName + "%' OR ProductTypeCode LIKE '%" + oProductType.ProductTypeName + "%'", 1, (int)Session[GlobalSession.UserID]);
            if (_oProductTypes.Count <= 0)
            {
                _oProductTypes = new List<ProductType>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oProductTypes);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}