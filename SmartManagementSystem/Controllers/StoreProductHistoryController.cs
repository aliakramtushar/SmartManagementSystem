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
    public class StoreProductHistoryController : Controller
    {
        StoreProductHistory _oStoreProductHistory = new StoreProductHistory();
        List<StoreProductHistory> _oStoreProductHistorys = new List<StoreProductHistory>() { };
        StoreProductHistoryService _oStoreProductHistoryService = new StoreProductHistoryService();
        Store _oStore = new Store();
        StoreService _oStoreService = new StoreService();
        List<Store> _oStores = new List<Store>();
        public ActionResult ViewStoreProductHistorys(int nBUID, int nUserID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            nUserID = Convert.ToInt32(Session["UserID"].ToString());

            _oStoreProductHistorys = _oStoreProductHistoryService.Gets("SELECT TOP(200)* FROM View_StoreProductHistory ORDER BY DBServerDateTime DESC", (int)Session[GlobalSession.UserID]);
            ViewBag.Stores = _oStoreService.Gets(1, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oStoreProductHistorys);
        }
        [HttpPost]
        public JsonResult Search(StoreProductHistory oStoreProductHistory)
        {
            int nCount = 0;
            string sStartDate = oStoreProductHistory.ErrorMessage.Split('~')[nCount++];
            string sEndDate = oStoreProductHistory.ErrorMessage.Split('~')[nCount++];
            int nStoreID = Convert.ToInt32(oStoreProductHistory.ErrorMessage.Split('~')[nCount++]);
            string sProductName = oStoreProductHistory.ErrorMessage.Split('~')[nCount++];
            string sCustomerName = oStoreProductHistory.ErrorMessage.Split('~')[nCount++];
            int nOperation = Convert.ToInt32(oStoreProductHistory.ErrorMessage.Split('~')[nCount++]);

            string sSQL = "SELECT * FROM View_StoreProductHistory WHERE DBServerDateTime BETWEEN '" + sStartDate + "' AND '" + sEndDate + "' ";
            if(nStoreID>0)
            {
                sSQL = sSQL + " AND StoreID =" + nStoreID;
            }

            if (!string.IsNullOrEmpty(sProductName))
            {
                sSQL = sSQL + " AND ProductName LIKE '%"+ sProductName + "%'";
            }
            if (!string.IsNullOrEmpty(sCustomerName))
            {
                sSQL = sSQL + " AND CustomerName LIKE '%" + sCustomerName + "%'";
            }
            if (nOperation > 0)
            {
                sSQL = sSQL + " AND OperationID =" + nStoreID;
            }
            _oStoreProductHistorys = _oStoreProductHistoryService.Gets(sSQL + " ORDER BY DBServerDateTime DESC", (int)Session[GlobalSession.UserID]);
            if (_oStoreProductHistorys.Count <= 0)
            {
                _oStoreProductHistorys = new List<StoreProductHistory>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oStoreProductHistorys);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}