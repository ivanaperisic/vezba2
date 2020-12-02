
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBusiness
    {
            public StudentRepository sr;
            public StudentBusiness()
            {
                this.sr = new StudentRepository();
            }
            public List<Student> GetStudents()
            {
                return this.sr.GetStudents();
            }
            public bool insertStudent(Student s)
            {
                int result = this.sr.insertStudent(s);
                if (result != 0)
                    return true;
                return false;

            }
        }
    }