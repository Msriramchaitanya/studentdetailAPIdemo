using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentdetailAPIdemo.Models
{
    public class studentDetails
    {
        [Key]
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public int Class { get; set; }
        public int Grade { get; set; }
        public int  FeeBalance { get; set; }
        public string State { get; set; }


    }
}
