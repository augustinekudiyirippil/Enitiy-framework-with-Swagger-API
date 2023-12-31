using Enitiy_framework_with_Swagger_API.Context;
using Enitiy_framework_with_Swagger_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enitiy_framework_with_Swagger_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly CRUDContext  _CRUDContext;


        public StudentController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }



        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _CRUDContext.students;

        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _CRUDContext.students.SingleOrDefault(x=> x.studentID==id);

        }



        // POST api/Students
        [HttpPost]
        public void Post([FromBody] Student student)
        {

            _CRUDContext.students.Add(student);
            _CRUDContext.SaveChanges();



        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Student student)
        {
            _CRUDContext.students.Add(student);
            _CRUDContext.SaveChanges();


        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

           
            var studentToDelete = _CRUDContext.students.SingleOrDefault(x => x.studentID == id);
            if (studentToDelete != null)
            {



                _CRUDContext.students.Remove(studentToDelete);
                _CRUDContext.SaveChanges();

            }


        }
    }
}
