using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureSathi.App_Start
{

    public static class Commanrepo
    {
        public static List<SelectListItem> getsubstationTYpe()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblSubscriptions.Select(s => new { s.id, s.Type }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Type;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetGender()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblGenders.Select(s => new { s.id, s.Gender }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Gender;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetAge()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblAges.Select(s => new { s.id, s.Age }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Age;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetReligion()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblReligions.Select(s => new { s.id, s.Religion }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Religion;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetEducation()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblEducations.Select(s => new { s.id, s.Education }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Education;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetMarital_Status()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblMaritalStatus.Select(s => new { s.id, s.Status }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Status;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetProfession()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblProfessions.Select(s => new { s.id, s.Profession }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Profession;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetIncome()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblIncomes.Select(s => new { s.id, s.Income }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Income;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetCity()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblCities.Select(s => new { s.id, s.City }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.City;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetState()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblStates.Select(s => new { s.id, s.State }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.State;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GEtHeight()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblHeights.Select(s => new { s.id, s.Height }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Height;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetBody_Type()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblBodyTypes.Select(s => new { s.id, s.BodyType }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.BodyType;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetDiet()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblDiets.Select(s => new { s.id, s.Diet }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Diet;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }

        public static List<SelectListItem> GetComplextion()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (var ctx = new FutureSathiEntities())
            {
                var obj = ctx.tblComplextions.Select(s => new { s.id, s.Complextion }).ToList();
                foreach (var item in obj)
                {
                    SelectListItem t = new SelectListItem();
                    t.Text = item.Complextion;
                    t.Value = item.id.ToString();
                    list.Add(t);
                }

                return list;
            }
        }
    }
}
