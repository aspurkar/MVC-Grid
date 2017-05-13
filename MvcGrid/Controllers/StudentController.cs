using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult all()
        {
            return View(GetList());
        }
        public ActionResult View(int studentid)
        {
            var list = GetList();
            var stud = list.Where(s => s.StudentId == studentid).FirstOrDefault();
            return View("view2",stud);
        }
        public ActionResult edit(int studentid)
        {
            var list = GetList();
            var stud = list.Where(s => s.StudentId == studentid).FirstOrDefault();
            return View(stud);
        }
        [HttpPost]
        public ActionResult edit(Student model)
        {
            Replace(model);
            return View("all", GetList());
        }
        public ActionResult delete(int studentid)
        {
            Delete(studentid);
            return View("all", GetList());
        }
        public ActionResult addstudent()
        {
            return View("add2");
        }
        [HttpPost]
        public ActionResult addstudent(Student model)
        {
            AddStudent(model);
            return View("all", GetList());
        }
        #region private methods
        private List<Student> GetList()
        {
            if (Session["list"] != null)
            {
                return Session["list"] as List<Student>;
            }
            else
            {
                var list = new List<Student>();
                var s1 = new Student();
                s1.Name = "Ajay";
                s1.Email = "ajay@yahoo.com";
                s1.Mobile = "88884535435";
                s1.City = "Amravati";
                s1.StudentId = 1001;
                list.Add(s1);

                s1 = new Student();
                s1.Name = "Aditya";
                s1.Email = "aditya@yahoo.com";
                s1.Mobile = "9000035435";
                s1.City = "Nagpur";
                s1.StudentId = 1002;
                list.Add(s1);

                s1 = new Student();
                s1.Name = "Vijay";
                s1.Email = "vijay@gmail.com";
                s1.Mobile = "85543590535";
                s1.City = "Mumbai";
                s1.StudentId = 1003;
                list.Add(s1);

                s1 = new Student();
                s1.Name = "Pankaj";
                s1.Email = "pank123@yahoo.com";
                s1.Mobile = "9111451234";
                s1.City = "Pune";
                s1.StudentId = 1004;
                list.Add(s1);

                Session["list"] = list;
                return list;
            }
        }
        private void AddStudent(Student s)
        {
            var list = GetList();
            list.Add(s);
            Session["list"] = list;
        }
        private void Delete(int studId)
        {
            var list = GetList();
            var studToRemove = list.Where(t => t.StudentId == studId).FirstOrDefault();
            list.Remove(studToRemove);
            Session["list"] = list;
        }
        private void Replace(Student updatedStud)
        {
            var list = GetList();
            var studToRemove = list.Where(s => s.StudentId == updatedStud.StudentId).FirstOrDefault();
            list.Remove(studToRemove);
            list.Add(updatedStud);
            Session["list"] = list;
        }
        #endregion
    }
}
