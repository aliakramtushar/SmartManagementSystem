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
    public class StoreController : Controller
    {
        Store _oStore = new Store();
        List<Store> _oStores = new List<Store>() { };
        StoreService _oStoreService = new StoreService();
        public ActionResult ViewStores(int nBUID, int nUserID)
        {
            _oStores = _oStoreService.Gets(nBUID, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oStores);
        }
        public ActionResult ViewStore(int nStoreID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Store _oStore = new Store();
            if (nStoreID > 0)
            {
                _oStore = _oStoreService.Get(nStoreID, (int)Session[GlobalSession.UserID]);
            }
            return View(_oStore);
        }
        [HttpPost]
        public JsonResult IUD(Store oStore)
        {
            _oStore = new Store();
            StoreService oStoreService = new StoreService();
            try
            {
                _oStore = oStore;
                _oStore = oStoreService.IUD(oStore, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oStore = new Store();
                _oStore.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStore);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(Store oStore)
        {
            _oStore = new Store();
            _oStore = oStore;
            StoreService oStoreService = new StoreService();
            try
            {
                List<StoreProduct> oStoreProducts = new List<StoreProduct>();
                StoreProductService oStoreProductService = new StoreProductService();
                oStoreProducts = oStoreProductService.Gets("SELECT * FROM View_StoreProduct WHERE StoreID = " + _oStore.StoreID, (int)Session[GlobalSession.UserID]);
                if(oStoreProducts.Count==0)
                {
                    _oStore.ErrorMessage = oStoreService.Delete(oStore, (int)Session[GlobalSession.UserID]);
                }
                else
                {
                    _oStore.ErrorMessage = "You Can Not Delete This Store. This Store Is Not Empty";
                }
            }
            catch (Exception ex)
            {
                _oStore = new Store();
                _oStore.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStore);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(Store oStore)
        {
            _oStores = _oStoreService.Gets("SELECT * FROM View_Store WHERE StoreName LIKE '%" + oStore.StoreName + "%'", 0, (int)Session[GlobalSession.UserID]);
            if (_oStores.Count <= 0)
            {
                _oStores = new List<Store>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStores);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }

    }
}