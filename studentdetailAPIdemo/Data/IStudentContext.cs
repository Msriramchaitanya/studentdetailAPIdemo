using Microsoft.EntityFrameworkCore;
using studentdetailAPIdemo.Models;

namespace studentdetailAPIdemo.Data
{
    public interface IStudentContext
    {
        DbSet<studentDetails> Students { get; set; }
    }
}