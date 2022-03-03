using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using studentdetailAPIdemo.Data;
using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext dbContext;
         
        public StudentRepository(StudentContext DbContext)
        {
         dbContext = DbContext;
        }
        public studentDetails  AddStudent(studentDetails detail)
        {

            dbContext.studentDetails.Add(detail);
            dbContext.SaveChanges();
            return detail;
            

            
        }

        public void DeleteStudent(int studentId)
        {
            SqlParameter intake = new SqlParameter("@ID",studentId);
            dbContext.studentDetails.FromSqlRaw("DeleteStudentDetail @ID",intake).ToList();
         }

        public IEnumerable<studentDetails> GetStudentDetails()
        {
            //var categories = dbContext.studentDetails.ToList();
            //return categories;
            return  dbContext.studentDetails.ToList();
        }

        public studentDetails UpdateStudent(studentDetails detail)
        {
            //SqlParameter update = new SqlParameter();
            dbContext.studentDetails.Update(detail);
            dbContext.SaveChanges();
            return detail;
        }
        //public studentDetails UpdateStudent(studentDetails detail)
        //{
        //    SqlParameter update = new SqlParameter("@Student_ID",detail);
        //    dbContext.studentDetails.FromSqlRaw("UpdateStudentDetails @Student_ID",update);
        //    //dbContext.studentDetails.Update(detail);
        //    dbContext.SaveChanges();
        //    return detail;
        //}
    }
}
