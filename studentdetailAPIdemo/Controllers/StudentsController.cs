using Microsoft.AspNetCore.Mvc;
using studentdetailAPIdemo.Models;
using studentdetailAPIdemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace studentdetailAPIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/<StudentsController>
        private readonly IStudentRepository _repo;

        public StudentsController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<studentDetails> Get()
        {
            return _repo.GetStudentDetails();
        }
       

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public studentDetails  Post([FromBody] studentDetails value)
        {
            return _repo.AddStudent(value);
            

        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] studentDetails value)
        {
             _repo.UpdateStudent(value);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete]
        public void Delete(studentDetails Student)
        {
            _repo.DeleteStudent(Student.studentId);
        }
    }
}
