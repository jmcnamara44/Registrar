using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RegistrarApp;
using System;

namespace RegistrarApp.Models
{
  public class Course
  {
    private int _id;
    private string _courseName;

    public Course(string courseName, int Id = 0)
    {
      _id = Id;
      _courseName = courseName;
    }
    public override bool Equals(System.Object otherCourse)
    {
        if (!(otherCourse is Course))
        {
          return false;
        }
        else
        {
          Course newCourse = (Course) otherCourse;
          bool idEquality = (this.GetId() == newCourse.GetId());
          bool courseNameEquality = (this.GetCourseName() == newCourse.GetCourseName());
          return (idEquality && courseNameEquality);
        }
    }
    public override int GetHashCode()
    {
        return this.GetCourseName().GetHashCode();
    }
    public int GetId()
    {
      return _id;
    }
    public string GetCourseName()
    {
      return _courseName;
    }
    public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM courses;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string courseName = rdr.GetString(1);
        Course newCourse = new Course(courseName, courseId);
        allCourses.Add(newCourse);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCourses;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO courses (course_name) VALUES (@courseName);";

      MySqlParameter courseName = new MySqlParameter();
      courseName.ParameterName = "@courseName";
      courseName.Value = this._courseName;
      cmd.Parameters.Add(courseName);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
          conn.Dispose();
      }
    }

    public void AddStudent(Student newStudent)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO course_student (course_id, student_id) VALUES (@courseId, @studentId);";

      cmd.Parameters.Add(new MySqlParameter("@courseId", _id));
      cmd.Parameters.Add(new MySqlParameter("@studentId", newStudent.GetId()));
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public List<Student> GetStudents()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT students.* FROM courses
            JOIN course_student ON (courses.id = course_student.course_id)
            JOIN students ON (course_student.student_id = students.id)
            WHERE courses.id = @CourseId;";

        MySqlParameter courseIdParameter = new MySqlParameter();
        courseIdParameter.ParameterName = "@CourseId";
        courseIdParameter.Value = _id;
        cmd.Parameters.Add(courseIdParameter);

        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        List<Student> students = new List<Student>{};

        while(rdr.Read())
        {
          int studentId = rdr.GetInt32(0);
          string studentName = rdr.GetString(1);
          Student newStudent = new Student(studentName, studentId);
          students.Add(newStudent);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return students;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM courses; DELETE FROM course_student;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
  }
}
