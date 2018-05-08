using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrarApp.Models;
using System.Collections.Generic;
using System;



namespace RegistrarApp.Tests
{

    [TestClass]
    public class CourseTests : IDisposable
    {
        public void Dispose()
        {
            Course.DeleteAll();
            Student.DeleteAll();
        }
        public CourseTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=registrar_test;";
        }
        // [TestMethod]
        // public void GetAll_DbStartsEmpty_0()
        // {
        //   //Arrange
        //   //Act
        //   int result = Course.GetAll().Count;
        //   //Assert
        //   Assert.AreEqual(0, result);
        // }
        // [TestMethod]
        // public void Save_SavesToDatabase_CourseList()
        // {
        //
        //   Course newCourse = new Course("math");
        //   Course otherCourse = new Course("english");
        //   newCourse.Save();
        //   otherCourse.Save();
        //   List <Course> courseList = new List<Course>{newCourse, otherCourse};
        //   List <Course> result = Course.GetAll();
        //   CollectionAssert.AreEqual(courseList, result);
        // }
        // [TestMethod]
        // public void GetStudents_Empty_Table()
        // {
        //   Course testCourse = new Course("math");
        //   int result = testCourse.GetStudents().Count;
        //   Console.WriteLine(result);
        //   Assert.AreEqual(0, result);
        // }
        [TestMethod]
        public void AddStudent_JoinTableCompiles_ListOfStudents()
        {
          Course testCourse = new Course("math");
          testCourse.Save();
          Course testCourse1 = new Course("english");
          testCourse1.Save();
          Student newStudent1 = new Student("rita");
          newStudent1.Save();
          testCourse.AddStudent(newStudent1);
          Student newStudent2 = new Student("bert");
          newStudent2.Save();
          testCourse1.AddStudent(newStudent2);
          Student newStudent3 = new Student("dan");
          newStudent3.Save();
          testCourse1.AddStudent(newStudent3);
          List<Student> result = testCourse1.GetStudents();
          foreach (var student in result)
          {
            Console.WriteLine("Look here "+ student.GetStudentName());
          }
          List<Student> manualList = new List<Student>{newStudent2, newStudent3};

          CollectionAssert.AreEqual(manualList, result);
        }


    }
}
