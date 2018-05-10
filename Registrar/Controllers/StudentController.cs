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
        [HttpGet("/student-course-list/{id}")]
        public ActionResult StudentPage(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>{};
            Student foundStudent = Student.Find(id);
            List<Course> studentCourses = foundStudent.GetCourses();
            List<Course> allCourses = Course.GetAll();
            model.Add("studentCourses", studentCourses);
            model.Add("allCourses", allCourses);
            model.Add("foundStudent", foundStudent);
            return View(model);
        }
        [HttpPost("/add-course-to-student/{id}")]
        public ActionResult CreateCourse(int id)
        {
            Student newStudent = Student.Find(id);
            int studentId = newStudent.GetId();
            Course newCourse = Course.Find(Int32.Parse(Request.Form["course-name"]));
            newCourse.AddStudent(newStudent);
            return RedirectToAction("StudentPage", new { id = studentId} );
        }
        [HttpGet("/delete-student/{id}")]
        public ActionResult DeleteStudent(int id)
        {
            Student deleteStudent = Student.Find(id);
            deleteStudent.DeleteStudent();
            return RedirectToAction("AddStudent");
        }
    }
}
