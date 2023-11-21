using FutureSathi.IServices;
using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureSathi.Services
{
    public class UserRepo : IUser
    {
        FutureSathiEntities ctx = new FutureSathiEntities();
       
        public dynamic GetPartialById(int id)   //--->Prasad Bhalerao_20-11-2023 13.30.00
        {
            var obj = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Last_Name, Age = s.tblAge.Age, gender = s.tblGender.Gender, religion = s.tblReligion.Religion, Photos=s.Photo_1}).Where(w => w.id == id).ToList();
            return obj;
        }

        public dynamic GetPartialUserByGender(string o)  //--->Prasad Bhalerao_20-11-2023 13.30.00
        {
            if (o.Trim() == "Male")
            {
                var oList = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Last_Name, Age = s.tblAge.Age, gender = s.tblGender.Gender, religion = s.tblReligion.Religion }).Where(w => w.gender.Trim()== "Female").ToList();
               
                return oList;
            }
            if (o.Trim()=="Female")
            {
                var oList = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Last_Name, Age = s.tblAge.Age, gender = s.tblGender.Gender, religion = s.tblReligion.Religion }).Where(w => w.gender.Trim() == "Male").ToList();
                
                return oList;
            }
            
            return null;
        }


        UserClass temp;
        public bool Login(UserClass obj)   //--->Prasad Bhalerao_20-11-2023 13.30.00
        {

            temp = obj;
            var O = ctx.tblUsers.Where(w => w.Email.ToLower() == temp.Email.ToLower() && w.Password == temp.Password).FirstOrDefault();

            if (O!=null)
            {
                return true;
            }
            return false;
        }

        public bool Signin(UserClass obj) 
        {
            if (obj != null)
            {
                try
                {
                    tblUser U = new tblUser();
                    U.First_Name = obj.First_Name;
                    U.Last_Name = obj.Last_Name;
                    U.Gender_id = obj.Gender_id;
                    U.Contact = obj.Mobile_No;
                    U.Email = obj.Email;
                    U.Password = obj.Password;


                    ctx.tblUsers.Add(U);
                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false; 

                }
            }

            return false;
        }

        public dynamic GetGender(string u)   //--->Prasad Bhalerao_20-11-2023 13.30.00
        {
            if (u != null)
            {
                var obj = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Last_Name, s.Email, Age = s.tblAge.Age, gender = s.tblGender.Gender, religion = s.tblReligion.Religion, income = s.tblIncome.Income }).Where(w => w.Email == u).FirstOrDefault();

                return obj.gender;
            }

            return null;
        }
    }
}