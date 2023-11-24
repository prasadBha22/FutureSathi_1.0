using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureSathi.Models
{
    public class MessageCode
    {
        public int Code { get; set; }

        public dynamic Message { get; set; }

        public dynamic ReturnMessage { get; set; }


        public dynamic AgeDrop { get; set; }
        public dynamic GenderDrop { get; set; }
        public dynamic ReligionDrop { get; set; }
        public dynamic EducationDrop { get; set; }
        public dynamic MaritalstatusDrop { get; set; }
        public dynamic ProffesionDrop { get; set; }
        public dynamic IncomeDrop { get; set; }
        public dynamic CityDrop { get; set; }
        public dynamic StateDrop { get; set; }
        public dynamic BodytypeDrop { get; set; }
        public dynamic DietDrop { get; set; }
        public dynamic ComplexionDrop { get; set; }

        public dynamic HeightDrop { get; set; }
        public dynamic LookingForDrop { get; set; }

    }
}