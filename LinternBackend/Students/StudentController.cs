using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using LinternBackend.User;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.Students
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepo;
        private readonly IUserRepository _userRepo;
        private readonly AppDbContext _context;
        public StudentController(
            IStudentRepository studentRepo,
            AppDbContext context,
            IUserRepository userRepo
            )
        {
            _studentRepo = studentRepo;
            _context = context;
            _userRepo = userRepo; 
        }

        [HttpPost("create")]
        public async Task<IActionResult> createStudent([FromBody] CreateStudent createStudent)
        {
            var student = createStudent.ToStudent();
            var result = await _studentRepo.createStudentAsync(student, createStudent.password);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var token = await _userRepo.token(result.student.UserId);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return Ok( new
            {
                ViewStudent = result.student?.FromStudent(),
                token = token
                }
                );

        }
  
    }
}