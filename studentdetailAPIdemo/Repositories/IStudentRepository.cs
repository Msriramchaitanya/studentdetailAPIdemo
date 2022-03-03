using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Repositories
{
    public interface IStudentRepository
    {
        public studentDetails AddStudent(studentDetails detail);
       
        IEnumerable<studentDetails> GetStudentDetails();
        public void DeleteStudent(int studentId);
       public studentDetails UpdateStudent(studentDetails detail);
    }
}
