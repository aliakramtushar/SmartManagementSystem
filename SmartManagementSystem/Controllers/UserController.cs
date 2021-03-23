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
    public class UserController : Controller
    {
        User _oUser = new User();
        List<User> _oUsers = new List<User>() { };
        UserService _oUserService = new UserService();
        public ActionResult ViewUsers(int nBUID, int nUserID)
        {
            _oUsers = _oUserService.Gets(nBUID, (int)Session[GlobalSession.UserID]);
            _oUsers = _oUsers.Where(x =>x.Activity == true).ToList();
            _oUser = _oUserService.Get((int)Session[GlobalSession.UserID], (int)Session[GlobalSession.UserID]);
            ViewBag.LoginUser = _oUser;
            ViewBag.BUID = nBUID;
            return View(_oUsers);
        }
        public ActionResult ViewUser(int nUserID)
        {
            GlobalSession.SessionIsAlive(Session, Response);

            User _oUser = new User();
            if (nUserID > 0)
            {
                _oUser = _oUserService.Get(nUserID, (int)Session[GlobalSession.UserID]);
            }
            ViewBag.UserTypes = Enum.GetValues(typeof(EnumUserType)).Cast<EnumUserType>().Select(e => new EnumClass { Id = ((int)e), Name = e.ToString() });
            return View(_oUser);
        }
        [HttpPost]
        public JsonResult IUD(User oUser)
        {
            _oUser = new User();
            UserService oUserService = new UserService();
            try
            {
                _oUser = oUser;
                _oUser = oUserService.IUD(oUser, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oUser = new User();
                _oUser.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oUser);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(User oUser)
        {
            _oUser = new User();
            UserService oUserService = new UserService();
            try
            {
                _oUser = oUser;
                _oUser.ErrorMessage = oUserService.Delete(oUser, (int)Session[GlobalSession.UserID]);
            }
            catch (Exception ex)
            {
                _oUser = new User();
                _oUser.ErrorMessage = ex.Message;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oUser);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(User oUser)
        {
            _oUsers = _oUserService.Gets("SELECT * FROM View_User WHERE UserName LIKE '%" + oUser.UserName + "%' OR UserShortName LIKE '%" + oUser.UserName + "%' AND Validity = 1", 0, (int)Session[GlobalSession.UserID]);
            if(_oUsers.Count<=0)
            {
                _oUsers = new List<User>();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(_oUsers);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}