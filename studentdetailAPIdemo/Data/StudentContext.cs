using Microsoft.EntityFrameworkCore;
using studentdetailAPIdemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Data
{
    public class StudentContext : DbContext
    {
       

        public StudentContext(DbContextOptions<StudentContext> dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();

        }
        public DbSet<studentDetails> studentDetails { get; set; }
      
    }
}
