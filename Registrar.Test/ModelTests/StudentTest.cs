using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrarApp.Models;
using System.Collections.Generic;
using System;



namespace RegistrarApp.Tests
{

    [TestClass]
    public class StudentTests : IDisposable
    {
        public void Dispose()
        {
            Student.DeleteAll();
            Course.DeleteAll();
        }
        public StudentTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=registrar_test;";
        }
        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
          //Arrange
          //Act
          int result = Student.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Save_SavesToDatabase_StudentList()
        {

          Student newStudent = new Student("Helen");
          Student otherStudent = new Student("bob");
          newStudent.Save();
          otherStudent.Save();
          List <Student> studentList = new List<Student>{newStudent, otherStudent};
          List <Student> result = Student.GetAll();
          CollectionAssert.AreEqual(studentList, result);
        }
        [TestMethod]
        public void GetCourses_PullsFromCourseTable_CourseList()
        {
          Course newCourse = new Course("math");
          newCourse.Save();
          Student newStudent = new Student("Jimmy");
          newStudent.Save();
          newStudent.AddCourse(newCourse);

          Console.WriteLine("newstudent id: " + newStudent.GetId());
          Console.WriteLine("newcourse id: " + newCourse.GetId());

          List <Course> courseList = new List<Course>{newCourse};
          List <Course> DBcourseList = newStudent.GetCourses();
          CollectionAssert.AreEqual(courseList, DBcourseList);
        }

    }
}
