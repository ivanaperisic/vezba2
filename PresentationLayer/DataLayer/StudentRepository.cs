
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StudentRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> studentList = new List<Student>();
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString)) 
            {
                con.Open();
                string CommandText = "Select * from Students";
                SqlCommand com = new SqlCommand(CommandText, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Student s = new Student(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetDecimal(3));
                    studentList.Add(s);
                }
            }
            return studentList;

        }



        public int insertStudent(Student s)
        {
            int result;
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString)) 
            {
                con.Open();
                string CommandText = "Insert into Students(name,indexNumber,averageMark) values(@name,@indexNumber,@averageMark)";
                SqlCommand com = new SqlCommand(CommandText, con);
                com.Parameters.AddWithValue("@name", s.name);
                com.Parameters.AddWithValue("@indexNumber", s.indexNumber);
                com.Parameters.AddWithValue("@averageMark", s.averageMark);
                result = com.ExecuteNonQuery();

            }


            return result;
        }
    }
}
