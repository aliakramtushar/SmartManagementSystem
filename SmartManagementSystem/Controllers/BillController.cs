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
using Reports;

namespace SmartManagementSystem.Controllers
{
    public class BillController : Controller
    {
        Bill _oBill = new Bill();
        List<Bill> _oBills = new List<Bill>() { };
        List<BillDetail> _oBillDetails = new List<BillDetail>();
        BillService _oBillService = new BillService();
        BillDetailService _oBillDetailService = new BillDetailService();
        public ActionResult ViewBills(int nBUID, int nUserID)
        {
            _oBills = _oBillService.Gets("SELECT TOP(200) * FROM View_Bill WHERE BillID_Ref=0 ORDER BY BillDate DESC ", 1,(int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            User oUser = new User();
            UserService oUserService = new UserService();
            oUser = oUserService.Get((int)Session[GlobalSession.UserID], (int)Session[GlobalSession.UserID]);
            ViewBag.User = oUser;
            return View(_oBills);
        }
        public ActionResult ViewBill(int nBillID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Bill _oBill = new Bill();
            if (nBillID > 0)
            {
                _oBill = _oBillService.Get(nBillID, (int)Session[GlobalSession.UserID]);

                _oBillDetails = _oBillDetailService.GetsByBillID(_oBill.BillID, (int)Session[GlobalSession.UserID]);
            }
            else
            {
                Random random = new Random();
                _oBill.BillNo = random.Next(1, 99).ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            }
            ViewBag.BillDetails = _oBillDetails;
            List<Store> oStores = new List<Store>();
            StoreService oStoreService = new StoreService();
            oStores = oStoreService.Gets(1, (int)Session[GlobalSession.UserID]);
            List<StoreProduct> oStoreProducts = new List<StoreProduct>();
            ViewBag.Stores = oStores;
            ViewBag.StoreProducts = oStoreProducts;
            return View(_oBill);
        }
        public ActionResult ViewDueBills(int nBUID, int nUserID)
        {
            _oBills = _oBillService.Gets("SELECT HH.*, (ISNULL(HH.AmountToPaid,0) - ISNULL(HH.TotalPaidAmount,0)) AS YetToPay FROM View_Bill AS HH WHERE (ISNULL(HH.AmountToPaid,0) - ISNULL(HH.TotalPaidAmount,0)) > 0 AND BillID_Ref = 0", nBUID, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            User oUser = new User();
            UserService oUserService = new UserService();
            oUser = oUserService.Get((int)Session[GlobalSession.UserID], (int)Session[GlobalSession.UserID]);
            ViewBag.User = oUser;
            return View(_oBills);
        }
        public ActionResult ViewDueBill(int nBillID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Bill _oBill = new Bill();
            if (nBillID > 0)
            {
                _oBill = _oBillService.Get(nBillID, (int)Session[GlobalSession.UserID]);

                if (_oBill.BillID_Ref <= 0)
                {
                    _oBill.BillNo_Ref = _oBill.BillNo;
                    _oBill.YetToPay = (_oBill.AmountToPaid - _oBill.TotalPaidAmount);
                    _oBill.DueAmount = 0;
                   
                    _oBill.PaidTotal = 0;
                    _oBillDetails = _oBillDetailService.GetsByBillID(_oBill.BillID, (int)Session[GlobalSession.UserID]);
                }
                else
                    _oBillDetails = _oBillDetailService.GetsByBillID(_oBill.BillID_Ref, (int)Session[GlobalSession.UserID]);
            }
            else
            {
                throw new Exception("Exception: Invalid Due Bill.");
            }
            ViewBag.BillDetails = _oBillDetails;
            List<Store> oStores = new List<Store>();
            StoreService oStoreService = new StoreService();
            oStores = oStoreService.Gets(1, (int)Session[GlobalSession.UserID]);
            List<StoreProduct> oStoreProducts = new List<StoreProduct>();
            ViewBag.Stores = oStores;
            ViewBag.StoreProducts = oStoreProducts;
            return View(_oBill);
        }

        [HttpPost]
        public JsonResult IUD(Bill oBill)
        {
            _oBill = new Bill();
            BillService oBillService = new BillService();
            List<BillDetail> oBillDetails = new List<BillDetail>();
            BillDetailService oBillDetailService = new BillDetailService();
            oBillDetails = oBill.BillDetails;
            try
            {
                _oBill = oBill;
                _oBill = oBillService.IUD(oBill, (int)Session[GlobalSession.UserID]);
                if(_oBill.BillID>0)
                {
                    foreach(BillDetail obj in oBillDetails)
                    {
                        obj.BillID = _oBill.BillID;
                        oBillDetailService.IUD(obj, (int)Session[GlobalSession.UserID]);
                    }
                }
            }
            catch (Exception ex)
            {
                _oBill = new Bill();
                _oBill.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oBill);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(Bill oBill)
        {
            _oBill = new Bill();
            BillService oBillService = new BillService();
            try
            {
                _oBill = oBill;
                _oBill.ErrorMessage = oBillService.Delete(oBill, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oBill = new Bill();
                _oBill.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oBill);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteDetail(BillDetail oBillDetail)
        {
            BillDetailService oBillDetailService = new BillDetailService();
            BillDetail _oBillDetail = new BillDetail();
            try
            {
                _oBillDetail = oBillDetail;
                oBillDetail.ErrorMessage = oBillDetailService.Delete(oBillDetail, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oBill = new Bill();
                _oBill.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(oBillDetail);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Search(Bill oBill)
        {
            _oBills = _oBillService.Gets("SELECT Top(300)* FROM View_Bill WHERE BillNo LIKE '%" + oBill.BillNo + "%' OR CustomerName LIKE '%" + oBill.CustomerName + "%' OR CustomerMobile LIKE '%" + oBill.BillNo + "%' AND BillID_Ref=0 ORDER BY BillDate ASC", 0, (int)Session[GlobalSession.UserID]);
            if (_oBills.Count <= 0)
            {
                _oBills = new List<Bill>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oBills);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AllBill(Bill oBill)
        {
            _oBills = _oBillService.Gets("SELECT * FROM View_Bill WHERE BillNo LIKE '%" + oBill.BillNo + "%' ORDER BY BillDate ASC", 0, (int)Session[GlobalSession.UserID]);
            if (_oBills.Count <= 0)
            {
                _oBills = new List<Bill>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oBills);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult PrintBillPreview(int nBillID)
        {
            Bill _oBill = new Bill();
            if (nBillID > 0)
            {
                _oBill = _oBillService.Get(nBillID, (int)Session[GlobalSession.UserID]);
                if(_oBill.BillID_Ref==0)
                {
                    _oBill.BillDetails = _oBillDetailService.Gets("SELECT * FROM View_BillDetail WHERE BillID = " + nBillID, 0, (int)Session[GlobalSession.UserID]);
                }
                else
                {
                    _oBill.BillDetails = _oBillDetailService.Gets("SELECT * FROM View_BillDetail WHERE BillID = " + _oBill.BillID_Ref, 0, (int)Session[GlobalSession.UserID]);
                }
            }
            rptBill oReport = new rptBill();
            byte[] abytes = oReport.PrepareReport(_oBill);
            return File(abytes, "application/pdf");
        }

        public ActionResult PrintBillHistory(int nBillID)
        {
            _oBills = new List<Bill>();
            if (nBillID > 0)
            {
                _oBills = _oBillService.Gets("SELECT BB.* FROM View_Bill AS BB WHERE BB.BillID = "+ nBillID + " OR BB.BillID_Ref = "+ nBillID, 0, (int)Session[GlobalSession.UserID]);
            }

            rptBillHistory oReport = new rptBillHistory();
            byte[] abytes = oReport.PrepareReport(_oBills);
            return File(abytes, "application/pdf");
        }
    }
}