using FutureSathi.IServices;
using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.Controllers
{
    public class NotificationController : Controller
    {
        FutureSathiEntities ctx = new FutureSathiEntities();

   
        MessageCode rep = new MessageCode();

        IUser _user;

        public NotificationController(IUser m)
        {
            _user = m;
        }

        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNotificationData()
        {
            var objName = User.Identity.Name;
            var obj = ctx.tblUsers.Select(s => new { s.id, s.Email, Gender = s.tblGender.Gender }).Where(w => w.Email == objName).FirstOrDefault();


            var objj = _user.GetNotificationData(obj.id);
            return Json(objj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveChatStatus(int id)
        {
            var user = User.Identity.Name;
            var o = ctx.tblUsers.Select(s => new { s.id, s.Email,s.Contact }).Where(w => w.Email == user).FirstOrDefault();
            int UserId = o.id;
            var obj = _user.SaveStatusTrue(id,UserId);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }



    }
}