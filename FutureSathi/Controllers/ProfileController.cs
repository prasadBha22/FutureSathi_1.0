using FutureSathi.IServices;
using FutureSathi.Models;
using FutureSathi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        FutureSathiEntities ctx = new FutureSathiEntities();
        MessageCode msg = new MessageCode();
       
        IUser m;
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
            string Ui = User.Identity.Name.ToString();
            var obj = m.GetAllUserInfo(Ui);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditProfile(int id)
        {
            var obj = m.EditProfile(id);


            return Json(obj, JsonRequestBehavior.AllowGet);
        }



        public ActionResult getCity(int id)
        {
            var obj = m.getCity(id);


            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserClass obj)
        {

            bool returnvalue = false;
            obj.Photo_1 = photostatic.Photo;
            if (obj.Photo_1==null)
	        {   
               var user= ctx.tblUsers.Select(s=>new{s.id,s.Photo_1}).Where(w=>w.id==obj.Id).FirstOrDefault();
             obj.Photo_1=   user.Photo_1;

	        }

            if (obj.Religion_id == 0)
            {

                obj.Religion_id = ' ';
            }


            if (obj != null)
            {
                try
                {
                    tblUser u= new tblUser();

                    u.id = obj.Id;
                    u.First_Name = obj.First_Name;
                    u.Last_Name = obj.Last_Name;
                    u.Gender_id = obj.Gender_id;
                    u.Smoke_id = obj.Smoke_id;
                    u.Religion_id = obj.Religion_id;
                    u.Profession_id = obj.Profession_id;
                    u.State_id = obj.State_id;
                    u.City_id = obj.City_id;
                    u.Age_id = obj.Age_id;
                    u.Password = obj.Password;
                    u.Marital_Status_id = obj.Marital_Status_id;
                    u.Looking_for_id = obj.Looking_for_id;
                    u.Income_id = obj.Income_id;
                    u.Body_Type_id = obj.Body_Type_id;
                    u.Complextion_id = obj.Complextion_id;
                    u.Contact = obj.Mobile_No;
                    u.Diet_id = obj.Diet_id;
                    u.Photo_1 = obj.Photo_1;
                    u.Height_id = obj.Height_id;
                   
                    u.Education_id = obj.Education_id;
                    u.Email = obj.Email;
                    
                    u.Drink_id = obj.Drink_id;
                    u.Bio = obj.Bio;
                    //u.Family = obj.Family;



                    ctx.tblUsers.Attach(u);
                    
                    ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();

                    returnvalue = true;
                }
                catch (Exception er)
                {
                    returnvalue = false;
                    return Json(returnvalue, JsonRequestBehavior.AllowGet);
                }
            }

            
           


           

            photostatic.Photo = null;

           

            return Json(returnvalue, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserPhoto()
        {

        
            if (Request.Files.Count != 0)
            {

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);
                    
                    photostatic.Photo = file.FileName;
                   
                    var path = Path.Combine(Server.MapPath("~/UserPhoto/"), fileName);
                    file.SaveAs(path);
                    


                }


                return Json("yes", JsonRequestBehavior.AllowGet);

            }

            return Json("yes", JsonRequestBehavior.AllowGet);
        }

    }

}