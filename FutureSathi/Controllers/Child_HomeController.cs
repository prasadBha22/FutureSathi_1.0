using FutureSathi.IServices;
using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.Controllers
{
    
    
    //Prasad Bhalerao_20-11-2023 20.30.00
    public class Child_HomeController : Controller
    {
        //Globale variable 
        IUser _user;

        //Constructor
        public Child_HomeController(IUser user)
        {

            _user = user;
        }

        // GET: Child_HomePage
        public ActionResult cHome()
        {
            string str = User.Identity.Name;
            var temp = _user.GetGender(str);
            var userData = _user.GetPartialUserByGender(temp);

            ViewBag.msg = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
            return View();
        }
    }
}