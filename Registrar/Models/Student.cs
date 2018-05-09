using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RegistrarApp;
using System;

namespace RegistrarApp.Models
{
  public class Student
  {
    private int _id;
    private string _studentName;

    public Student(string studentName, int Id = 0)
    {
      _id = Id;
      _studentName = studentName;
    }
    public override bool Equals(System.Object otherStudent)
    {
        if (!(otherStudent is Student))
        {
          return false;
        }
        else
        {
          Student newStudent = (Student) otherStudent;
          bool idEquality = (this.GetId() == newStudent.GetId());
          bool studentNameEquality = (this.GetStudentName() == newStudent.GetStudentName());
          return (idEquality && studentNameEquality);
        }
    }
    public override int GetHashCode()
    {
        return this.GetStudentName().GetHashCode();
    }
    public int GetId()
    {
      return _id;
    }
    public string GetStudentName()
    {
      return _studentName;
    }
    public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM students;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        Student newStudent = new Student(studentName, studentId);
        allStudents.Add(newStudent);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStudents;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO students (student_name) VALUES (@studentName);";

      MySqlParameter studentName = new MySqlParameter();
      studentName.ParameterName = "@studentName";
      studentName.Value = this._studentName;
      cmd.Parameters.Add(studentName);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
          conn.Dispose();
      }
    }
    public void AddCourse(Course newCourse)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO course_student (course_id, student_id) VALUES (@courseId, @studentId);";

      cmd.Parameters.Add(new MySqlParameter("@courseId", newCourse.GetId()));
      cmd.Parameters.Add(new MySqlParameter("@studentId", _id));
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public List<Course> GetCourses()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT courses.* FROM students
            JOIN course_student ON (students.id = course_student.student_id)
            JOIN courses ON (course_student.course_id = courses.id)
            WHERE students.id = @StudentId;";

        MySqlParameter studentIdParameter = new MySqlParameter();
        studentIdParameter.ParameterName = "@StudentId";
        studentIdParameter.Value = _id;
        cmd.Parameters.Add(studentIdParameter);

        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        List<Course> courses = new List<Course>{};

        while(rdr.Read())
        {
          int courseId = rdr.GetInt32(0);
          string courseName = rdr.GetString(1);
          Course newCourse = new Course(courseName, courseId);
          courses.Add(newCourse);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return courses;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM students; DELETE FROM course_student;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }

    }
  }
}
