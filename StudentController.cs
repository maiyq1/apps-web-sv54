using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> Students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Carlos" ,LastName = "Gonbzales"},
            new Student() { Id = 2, Name = "Juan" ,LastName = "Gonbzales"},
            new Student() { Id = 3, Name = "Arturo",LastName = "Quiñanes" },
            new Student() { Id = 4, Name = "Laura" ,LastName = "Aguirre" },
            new Student() { Id = 5, Name = "Carlos",LastName = "Petri"},
        };

        // GET: api/Student/{name}
        [HttpGet("{name}",Name = "GetStudent")]
        public List<Student> GetbyName(string name)//No body
        {
            return Students.Where(student => student.Name ==  name).ToList();
        }

        // GET: api/Student/5
        [HttpGet("{id:int}", Name = "GetById")]

        public Student Get(int id)
        {
            return Students.Where(student => student.Id ==  id).Single();
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student.Name == "")
                return StatusCode(400);
            else
                return StatusCode(201);
        }

        // PUT: api/Student/5
[HttpPut("{id}")]
public IActionResult Put(int id, [FromBody] Student student)
{
    try
    {
        var existingStudent = Students.FirstOrDefault(s => s.Id == id);
        if (existingStudent == null)
        {
            return NotFound(404); // Not Found
        }
        else
        {
            if (student.Id == 0)
            {
                return BadRequest(400); // Bad Request
            }
            else
            {
                existingStudent.Id = student.Id;
                existingStudent.Name = student.Name;
                existingStudent.LastName = student.LastName;
                return Ok(200); // OK
            }
        }
    }
    catch (Exception e)
    {
        return StatusCode(500); // Internal Server Error
    }
}


      // DELETE: api/Student/5
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var student = Students.FirstOrDefault(s => s.Id == id);
    if (student == null)
    {
        return NotFound(404); 
    }
    else
    {
        Students.Remove(student);
        return Accepted(202);
    }
}

    }
}
