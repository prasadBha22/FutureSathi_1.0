using FutureSathi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureSathi.IServices
{
    public interface IUser
    {
        bool Signin(UserClass obj);  

        bool Login(UserClass obj);  //--->Prasad Bhalerao_20-11-2023 13.30.00

        dynamic GetPartialById(int id);  //--->Prasad Bhalerao_20-11-2023 13.30.00

        dynamic GetGender(string u);  //--->Prasad Bhalerao_20-11-2023 13.30.00

        dynamic GetPartialUserByGender(string s);  //--->Prasad Bhalerao_20-11-2023 13.30.00

        dynamic GetAllUserInfo(string Name);


      

    }

    
}