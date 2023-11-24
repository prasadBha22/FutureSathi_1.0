using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureSathi.Models
{
    public class UserClass
    {

        public int Id { get; set; }
        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public int Gender_id { get; set; }

        public string Email { get; set; }

        public string Mobile_No { get; set; }
        public string Password { get; set; }

        public int Looking_for_id { get; set; }

        public DateTime Dob{ get; set; }

        public  int Age_id { get; set; }

        public int Religion_id { get; set; }

        public int Education_id { get; set; }

        public int Marital_Status_id { get; set; }

        public int Profession_id { get; set; }

        public int Income_id { get; set; }

        public int Diet_id { get; set; }

        public string Contact { get; set; }

        public int City_id { get; set; }

        public int State_id { get; set; }

        public int Height_id { get; set; }

        public int Body_Type_id { get; set; }

        public int Complextion_id { get; set; }
        public string Bio { get; set; }
        public string Photo_1 { get; set; }
        public string Photo_2 { get; set; }

        public List<dynamic> PhotoList { get; set; }

        public string Photo_3 { get; set; }
        public string Family { get; set; }

        public int Subcription_id { get; set; }

        public bool Drink_id { get; set; }

        public bool Smoke_id { get; set; }


    }
}