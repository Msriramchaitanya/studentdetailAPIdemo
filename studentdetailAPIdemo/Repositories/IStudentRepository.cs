using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Repositories
{
    public interface IStudentRepository
    {
        public Task< studentDetails> AddStudent(studentDetails detail);
       
         Task< IEnumerable<studentDetails>> GetStudentDetails();
        public Task DeleteStudent(int studentId);
       public Task<studentDetails> UpdateStudent(studentDetails detail);
       Task< studentDetails >GetStudentDetailsById(int Id );
    }
}
