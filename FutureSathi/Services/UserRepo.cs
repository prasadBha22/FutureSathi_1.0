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

        MessageCode msg = new MessageCode();
       
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

      
        public dynamic GetAllUserInfoandWishlist(int id)
        {
            try
            {
                var obj = ctx.tblUsers.Select(s => new { s.id, s.Email }).Where(w => w.id == id).FirstOrDefault();
                var Users = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Last_Name, Marritalstatus = s.tblMaritalStatu.Status, Religion = s.tblReligion.Religion, Education = s.tblEducation.Education, Diet = s.tblDiet.Diet, s.Smoke_id, Gender = s.tblGender.Gender, s.Contact, s.Password, LookingFor = s.tblGender.Gender, s.DOB, Age = s.tblAge.Age, Profession = s.tblProfession.Profession, Income = s.tblIncome.Income, City = s.tblCity.City, State = s.tblState.State, Height = s.tblHeight.Height, body = s.tblBodyType.BodyType, Complextion = s.tblComplextion.Complextion, s.Bio, s.Photo_1, s.Photo_2, s.Photo_3, s.Family, Subsricption = s.tblSubscription.Type }).Where(w => w.id == obj.id).FirstOrDefault();


                var WishList = ctx.tblWishLists.Select(s => new { s.User_id, Age = s.tblAge.Age, MarritalStatus = s.Marital_Status, s.Religion, s.Education, s.Diet, s.Smoke, s.Drink, s.Body_Type, s.Comlextion, Height = s.tblHeight.Height, s.State, Income = s.tblIncome.Income, s.Profession }).Where(w => w.User_id == obj.id).FirstOrDefault();

                msg.Code = 0;
                msg.Message = Users;
                msg.ReturnMessage = WishList;
                return msg;
            }
            catch (Exception er)
            {
                msg.Code = -1;
                msg.Message = er.Message;
                msg.ReturnMessage = null;
                return msg;
            }


        }

        public dynamic GetNotificationData(int id)
        {
            if (id!=0)
            {
                var obj = ctx.tblNotifications.Where(w => w.Sender_id!=id && w.Reciver_id==id).ToList();

                List<dynamic> li = new List<dynamic>();

                foreach (var item in obj)
                {
                    var temp = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Last_Name, s.tblCity.City }).Where(w => w.id == item.Sender_id).FirstOrDefault();
                    li.Add(temp);
                }
               
                return li;

            }
            return null;
        }

        public dynamic SaveNotification(int Sid, int Rid)
        {
            var obj = ctx.tblNotifications.Select(s => new { s.Sender_id, s.Reciver_id }).Where(w => w.Sender_id == Sid && w.Reciver_id == Rid).FirstOrDefault();
            if (obj != null)
            {
                return null;
            }
            try
            {
                tblNotification N = new tblNotification();

                N.Sender_id = Sid;
                N.Reciver_id = Rid;
                ctx.tblNotifications.Add(N);
                ctx.SaveChanges();
                tblChat chat = new tblChat();

                chat.Sender_id = Sid;
                chat.Reciver_id = Rid;
                chat.Status = true;
                ctx.tblChats.Add(chat);
                ctx.SaveChanges();


                msg.Code = 0;
                msg.Message = "Save Request ";
               
            }
            catch (Exception er)
            {

                msg.Code = -1;
                msg.Message = er.Message;
            }

            return msg;
        }

        public dynamic SaveStatusTrue(int id,int o)
        {
            if (id > 0)
            {

                var temp = ctx.tblNotifications.Select(s => new { s.Sender_id, s.Reciver_id }).Where(w => w.Sender_id == id && w.Reciver_id == o && w.Sender_id != o ).FirstOrDefault();

                tblChat AcceptRequest = new tblChat();
                AcceptRequest.Sender_id = o;
                AcceptRequest.Reciver_id = id;
                AcceptRequest.Status = true;
                ctx.tblChats.Add(AcceptRequest);
                ctx.SaveChanges();
                msg.Code = 0;
                msg.Message = "Accepted";


                tblNotification N = new tblNotification();

                N.Sender_id = o;
                N.Reciver_id = id;
                ctx.tblNotifications.Add(N);
                ctx.SaveChanges();

                
            }
            return msg;
        }


        public dynamic GetAllUserInfo(string Name)
        {
            try
            {



                var obj = ctx.tblUsers.Select(s => new { s.id, s.Email }).Where(w => w.Email == Name).FirstOrDefault();
                var Users = ctx.tblUsers.Select(s => new { s.id, s.First_Name, s.Email, s.Last_Name, Marritalstatus = s.tblMaritalStatu.Status, Religion = s.tblReligion.Religion, Education = s.tblEducation.Education, Diet = s.tblDiet.Diet, s.Smoke_id, Gender = s.tblGender.Gender, s.Contact, s.Password, LookingFor = s.tblGender.Gender, s.DOB, Age = s.tblAge.Age, Profession = s.tblProfession.Profession, Income = s.tblIncome.Income, City = s.tblCity.City, State = s.tblState.State, Height = s.tblHeight.Height, body = s.tblBodyType.BodyType, Complextion = s.tblComplextion.Complextion, s.Bio, s.Photo_1, s.Photo_2, s.Photo_3, s.Family, Subsricption = s.tblSubscription.Type, s.Drink_id }).Where(w => w.id == obj.id).FirstOrDefault();


                var WishList = ctx.tblWishLists.Select(s => new { s.User_id, Agee = s.tblAge.Age, MarritalStatus = s.Marital_Status, s.Religion, s.Education, s.Diet, s.Smoke, s.Drink, s.Body_Type, s.Comlextion, Height = s.tblHeight.Height, s.State, Income = s.tblIncome.Income, s.Profession }).Where(w => w.User_id == obj.id).FirstOrDefault();

                msg.Code = 0;
                msg.Message = Users;
                msg.ReturnMessage = WishList;
                return msg;
            }
            catch (Exception er)
            {
                msg.Code = -1;
                msg.Message = er.Message;
                msg.ReturnMessage = null;
                return msg;
            }

        }

    }

}