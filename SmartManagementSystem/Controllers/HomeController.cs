using BusinessObject;
using SMSEngine;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSEngine.GlobalClass;

namespace SmartManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        UserService _oUserService = new UserService();
        User _oUser = new User();
        public ActionResult Index()
        {
            GlobalSession.SessionIsAlive(Session, Response);
            return View(_oUser);
        }
        public ActionResult ViewLogin()
        {
            //asdasdasd
            Session.Clear();
            return View(_oUser);
        }
        [HttpPost]
        public JsonResult ValidateLogin(User oUser)
        {
            _oUser = _oUserService.ValidateLogin(1, oUser);
            if(_oUser.Validity)
            {
                InitializeSessions(_oUser);
            }
            else
            {
                Session.Clear();
            }
            return Json(_oUser);
        }

        
        private void InitializeSessions(User oUser)
        {
            Session[GlobalSession.UserID] = oUser.UserID;
            Session[GlobalSession.UserName] = oUser.UserName;
        }

}
}