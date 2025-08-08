using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.Students
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepo;
        private readonly AppDbContext _context;
        public StudentController(IStudentRepository studentRepo, AppDbContext context)
        {
            _studentRepo = studentRepo;
            _context = context;
        }

        // [HttpPost("create")]
        // public async Task<IActionResult> createStudent([FromBody] CreateStudent createStudent)
        // {
        //     var student = createStudent.ToStudent();
        //     await _studentRepo.createStudentAsync(student, createStudent.password);
        //     return Ok(student.FromStudent());

        // }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudent request)
        {
            var student = new Student
            {
                Email = request.Email,
                FullName = request.FullName,
                University = request.University,
                CourseOfStudy = request.CourseOfStudy,
                Level = request.Level,
                DateOfBirth = request.DateOfBirth,
                Phone = request.Phone,
                LinkedInUrl = request.LinkedInUrl,
                GithubUrl = request.GithubUrl
            };
            var result = await _studentRepo.createStudentAsync(student, request.password);

            if (result.student == null)
                return BadRequest(result.text);

            return Ok(result.student);
        }
    }
}