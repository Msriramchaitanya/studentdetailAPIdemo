using AutoFixture.Xunit2;
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
        public async Task< IEnumerable<studentDetails>> Get()
        {
            return await _repo.GetStudentDetails();
        }
       

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task< studentDetails > Get(int id)
        {
            var result=await _repo.GetStudentDetailsById(id);
            return result;
        }
       
        // POST api/<StudentsController>
        [HttpPost]
        public async Task< studentDetails>  Post([FromBody] studentDetails value)
        {
            return await _repo.AddStudent(value);
            

        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] studentDetails value)
        {
             await _repo.UpdateStudent(value);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete]
        public async Task Delete(studentDetails Student)
        {
            await _repo.DeleteStudent(Student.studentId);
        }
    }
}
