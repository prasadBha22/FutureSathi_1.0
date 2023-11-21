using FutureSathi.IServices;
using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FutureSathi.Controllers
{
    public class Master_HomeController : Controller
    {
        //Create: Globle OBJ 
        IUser _User;



       // Create: Constructor

        public Master_HomeController(IUser m)
        {
            _User = m;

        }


        // GET: Master_Home   ---> Prasad Bhalerao_20-11-2023 20.30.00
        public ActionResult Index()
        {
            return View();
        }

        // Get: LogIn         ---> Prasad Bhalerao_20-11-2023 20.30.00
        public ActionResult Login()
        {

            return View();
        }

        //Post:Login           ---->Prasad Bhalerao_20-11-2023 20.30.00
        [HttpPost]
        public ActionResult Login(UserClass obj)
        {

           var temp= _User.Login(obj);
            if (temp==true)
            {
                FormsAuthentication.SetAuthCookie(obj.Email, false);
                return RedirectToAction("cHome", "Child_Home");
            }

            return View();
        }

        
    }
}