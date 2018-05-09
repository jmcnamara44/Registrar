using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RegistrarApp.Models;

namespace RegistrarApp.Controllers
{
    public class StudentController : Controller
    {

        [HttpGet("/view-add-student")]
        public ActionResult AddStudent()
        {
            List<Student> allStudents = Student.GetAll();
            return View(allStudents);
        }
        [HttpPost("/create-student")]
        public ActionResult CreateStudent()
        {
            Student newStudent = new Student(Request.Form["student-name"]);
            newStudent.Save();
            return RedirectToAction("AddStudent");
        }
    }
}
