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
    }
}
