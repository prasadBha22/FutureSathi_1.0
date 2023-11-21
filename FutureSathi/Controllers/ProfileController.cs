using FutureSathi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        FutureSathiEntities ctx = new FutureSathiEntities();
        IUser m ;
        public ProfileController(IUser _m)
        {
            m = _m;
        
        }
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetUser()
        {
          string Ui =User.Identity.Name.ToString();
            var obj = m.GetAllUserInfo(Ui);

            return Json(obj,JsonRequestBehavior.AllowGet);
        }
    }
}