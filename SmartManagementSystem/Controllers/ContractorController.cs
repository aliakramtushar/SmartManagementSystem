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
    public class ContractorController : Controller
    {
        Contractor _oContractor = new Contractor();
        List<Contractor> _oContractors = new List<Contractor>() { };
        ContractorService _oContractorService = new ContractorService();
        public ActionResult ViewSuppliers(int nBUID, int nUserID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oContractors = _oContractorService.GetsByContractorType(EnumContractorType.Supplier, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oContractors);
        }
        public ActionResult ViewSupplier(int nContractorID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Contractor _oContractor = new Contractor();
            if (nContractorID > 0)
            {
                _oContractor = _oContractorService.Get(nContractorID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ContractorTypes = Enum.GetValues(typeof(EnumContractorType)).Cast<EnumContractorType>().Select(e => new EnumClass { Id = ((int)e), Name = e.ToString() });
            return View(_oContractor);
        }

        public ActionResult ViewBuyers(int nBUID, int nUserID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oContractors = _oContractorService.GetsByContractorType(EnumContractorType.Buyer, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oContractors);
        }
        public ActionResult ViewBuyer(int nContractorID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Contractor _oContractor = new Contractor();
            if (nContractorID > 0)
            {
                _oContractor = _oContractorService.Get(nContractorID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ContractorTypes = Enum.GetValues(typeof(EnumContractorType)).Cast<EnumContractorType>().Select(e => new EnumClass { Id = ((int)e), Name = e.ToString() });
            return View(_oContractor);
        }

        public ActionResult ViewCustomers(int nBUID, int nUserID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            _oContractors = _oContractorService.GetsByContractorType(EnumContractorType.Customer, (int)Session[GlobalSession.UserID]);
            ViewBag.BUID = nBUID;
            return View(_oContractors);
        }
        public ActionResult ViewCustomer(int nContractorID)
        {
            GlobalSession.SessionIsAlive(Session, Response);
            Contractor _oContractor = new Contractor();
            if (nContractorID > 0)
            {
                _oContractor = _oContractorService.Get(nContractorID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.ContractorTypes = Enum.GetValues(typeof(EnumContractorType)).Cast<EnumContractorType>().Select(e => new EnumClass { Id = ((int)e), Name = e.ToString() });
            return View(_oContractor);
        }









        [HttpPost]
        public JsonResult IUD(Contractor oContractor)
        {
            _oContractor = new Contractor();
            ContractorService oContractorService = new ContractorService();
            try
            {
                _oContractor = oContractor;
                _oContractor = oContractorService.IUD(oContractor, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oContractor = new Contractor();
                _oContractor.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oContractor);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(Contractor oContractor)
        {
            _oContractor = new Contractor();
            ContractorService oContractorService = new ContractorService();
            try
            {
                _oContractor = oContractor;
                _oContractor.ErrorMessage = oContractorService.Delete(oContractor, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oContractor = new Contractor();
                _oContractor.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oContractor);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(Contractor oContractor)
        {
            _oContractors = _oContractorService.Gets("SELECT * FROM View_Contractor WHERE ContractorName LIKE '%" + oContractor.ContractorName + "%'", 0, (int)Session[GlobalSession.UserID]);
            if (_oContractors.Count <= 0)
            {
                _oContractors = new List<Contractor>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oContractors);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}