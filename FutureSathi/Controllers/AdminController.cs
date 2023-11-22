using FutureSathi.App_Start;
using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.Controllers
{
    public class AdminController : Controller
    {
     
        FutureSathiEntities ctx = new FutureSathiEntities();
    
        MessageCode rep = new MessageCode();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUser()
        {
            try
            {
                var list = ctx.tblUsers.Select(U => new { U.id, U.First_Name, U.Last_Name, U.Email, substationTYpe = U.tblSubscription.Type }).ToList();
                rep.Code = 0;
                rep.Message = list;
            }
            catch (Exception er)
            {
                rep.Code = 0;
                rep.Message = er.Message;
            }
            return Json(rep, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getsubstationTYpe()
        {
            rep.Code = 0;
            rep.Message = Commanrepo.getsubstationTYpe();
            return Json(rep, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string txt_Search)
        {

            var user = ctx.tblUsers.Select(U => new { U.id, U.First_Name, U.Last_Name, U.Email, substationTYpe = U.tblSubscription.Type }).Where(w => w.Email.Contains(txt_Search) || w.First_Name.Contains(txt_Search)).ToList();
            //List<Search> UserList = MP.Map<List<Search>>(user);

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(string email, int id)
        {
            try
            {
                var obj = ctx.tblUsers.Where(U => U.Email == email).FirstOrDefault();
                if (obj != null)
                {
                    obj.Subcription_id = id;
                    ctx.tblUsers.Attach(obj);
                    ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    rep.Code = 0;
                    rep.Message = "Updated";
                }
            }
            catch (Exception er)
            {
                rep.Code = 0;
                rep.Message = er.Message;
            }
            return Json(rep, JsonRequestBehavior.AllowGet);
        }
    }
}