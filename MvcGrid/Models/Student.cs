using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Models
{
    public class AdmissionType
    {
        public int AdmissionTypeId { get; set; }
        public string AdmissionTypeName { get; set; }
        public AdmissionType(int typeid,string typename)
        {
            this.AdmissionTypeId=typeid;
            this.AdmissionTypeName=typename;
        }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public bool IsMarried { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public int AdmissionTypeId { get; set; }

        public static IEnumerable<SelectListItem> GetAdmissionTypes()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Regular", Value = "1" });
            list.Add(new SelectListItem() { Text = "Intern", Value = "2"});
            list.Add(new SelectListItem() { Text = "Corporate", Value = "3" });
            return list;
        }
    }
}
