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
        public async Task< studentDetails>  AddStudent(studentDetails detail)
        {

            dbContext.studentDetails.Add(detail);
            await dbContext.SaveChangesAsync();
            return detail;
            

            
        }

       
        public async Task DeleteStudent(int studentId)
        {
            var Detail = await dbContext.studentDetails.FirstOrDefaultAsync(a => a.studentId == studentId);
            dbContext.Entry(Detail).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await dbContext.SaveChangesAsync();
            
        }

        public async Task< IEnumerable<studentDetails>> GetStudentDetails()
        {
           
            return  await dbContext.studentDetails.ToListAsync();
        }

        public  async Task< studentDetails> GetStudentDetailsById(int Id)
        {
            var Details = await dbContext.studentDetails.Where(a => a.studentId == Id).Select(a => a).ToListAsync();
            return Details.FirstOrDefault();

        }
       
        public async Task< studentDetails> UpdateStudent(studentDetails detail)
        {
            //SqlParameter update = new SqlParameter();
            dbContext.studentDetails.Update(detail);
            await dbContext.SaveChangesAsync();
            return detail;
        }
        
    }
}
