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
        // [TestMethod]
        // public void GetAll_DbStartsEmpty_0()
        // {
        //   //Arrange
        //   //Act
        //   int result = Student.GetAll().Count;
        //
        //   //Assert
        //   Assert.AreEqual(0, result);
        // }
        // [TestMethod]
        // public void Save_SavesToDatabase_StudentList()
        // {
        //
        //   Student newStudent = new Student("Helen");
        //   Student otherStudent = new Student("bob");
        //   newStudent.Save();
        //   otherStudent.Save();
        //   List <Student> studentList = new List<Student>{newStudent, otherStudent};
        //   List <Student> result = Student.GetAll();
        //   CollectionAssert.AreEqual(studentList, result);
        // }
        // [TestMethod]
        // public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        // {
        //   // Arrange, Act
        //   Item firstItem = new Item("Mow the lawn");
        //   Item secondItem = new Item("Mow the lawn");
        //
        //   // Assert
        //   Assert.AreEqual(firstItem, secondItem);
        // }
        // [TestMethod]
        // public void Save_SavesToDatabase_ItemList()
        // {
        //   //Arrange
        //   Item testItem = new Item("Mow the lawn");
        //
        //   //Act
        //   testItem.Save();
        //   List<Item> result = Item.GetAll();
        //   Console.WriteLine(result.Count);
        //   foreach(Item element in result)
        //   {
        //     Console.WriteLine("result: " + result);
        //   }
        //
        //
        //   List<Item> testList = new List<Item>{testItem};
        //   Console.WriteLine(testList.Count);
        //   Console.WriteLine("testItem "+testItem);
        //   Console.WriteLine("testList " +testList);
        //   //Assert
        //   CollectionAssert.AreEqual(testList, result);
        // }

        // [TestMethod]
        // public void Save_AssignsIdToObject_Id()
        // {
        //   //Arranges
        //   Item testItem = new Item("Mow the lawn");
        //
        //   //Act
        //   testItem.Save();
        //   Item savedItem = Item.GetAll()[0];
        //
        //   int result = savedItem.GetId();
        //   int testId = testItem.GetId();
        //
        //   Console.WriteLine("testId: " + testId);
        //   Console.WriteLine("result: " + result);
        //   //Assert
        //   Assert.AreEqual(testId, result);
        // }
        // [TestMethod]
        // public void Find_FindsItemInDatabase_Item()
        // {
        //   //Arrange
        //   Item testItem = new Item("Mow the lawn");
        //   testItem.Save();
        //
        //   //Act
        //   Item foundItem = Item.Find(testItem.GetId());
        //
        //   //Assert
        //   Assert.AreEqual(testItem, foundItem);
        // }

    }
}
