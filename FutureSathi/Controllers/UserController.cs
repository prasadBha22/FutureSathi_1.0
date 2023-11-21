using FutureSathi.IServices;
using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.Controllers
{
    public class UserController : Controller
    {
        FutureSathiEntities ctx = new FutureSathiEntities();

        MessageCode rep = new MessageCode();

        IUser _user;

        public UserController(IUser m)
        {
            _user = m;
        }

        //Prasad Bhalerao_20-11-2023 13.30.00
        [HttpPost]
        public ActionResult Signin(UserClass obj)
        {
            _user.Signin(obj);
            return Json(obj,JsonRequestBehavior.AllowGet);

        }

        //Get Partial UserById: API  --->Prasad Bhalerao_20-11-2023 13.30.00
        public ActionResult GetPartialUserById(int id)
        {
            var O = _user.GetPartialById(id);
            return Json(O, JsonRequestBehavior.AllowGet);

        }


        //Prasad: Child Home: API     --->Prasad Bhalerao_20-11-2023 13.30.00

        public JsonResult LoadGenderViseList(UserClass obj)
        {
          
            return Json(rep, JsonRequestBehavior.AllowGet);
        }
    }
}