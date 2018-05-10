using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RegistrarApp.Models;

namespace RegistrarApp.Controllers
{
    public class CourseController : Controller
    {

      [HttpGet("/view-add-course")]
      public ActionResult AddCourse()
      {
          List<Course> allCourses = Course.GetAll();
          return View(allCourses);
      }
      [HttpPost("/create-course")]
      public ActionResult CreateCourse()
      {
          Course newCourse = new Course(Request.Form["course-name"]);
          newCourse.Save();
          return RedirectToAction("AddCourse");
      }
      [HttpGet("/course-roster/{id}")]
      public ActionResult CourseRoster(int id)
      {
          Dictionary<string, object> model = new Dictionary<string, object>{};
          Course currentCourse = Course.Find(id);
          model.Add("course", currentCourse);
          List<Student> currentStudents = currentCourse.GetStudents();
          model.Add("students", currentStudents);
          List<Student> allStudents = Student.GetAll();
          // model.Add();
          return View(model);
      }
      [HttpGet("/delete-course/{id}")]
      public ActionResult DeleteCourse(int id)
      {
          Course deleteCourse = Course.Find(id);
          deleteCourse.DeleteCourse();
          return RedirectToAction("AddCourse");
      }
    }
}
