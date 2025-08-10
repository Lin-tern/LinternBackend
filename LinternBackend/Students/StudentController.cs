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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var student = createStudent.ToStudent();
            var result = await _studentRepo.createStudentAsync(student, createStudent.password);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var token = await _userRepo.token(result.student.UserId);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return Ok(new
            {
                ViewStudent = result.student?.FromStudent(),
                token = token
            }
                );

        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAllStudents()
        {
            return Ok(await _studentRepo.getAll());
        }

        [HttpGet("getbyid/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            Console.WriteLine($"[GET] Received ID: {id}");
            var student = await _studentRepo.getStudentById(id);
            if (student == null) return StatusCode(404, "Student not found");
            return Ok(student.FromStudent());
        }
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> updateStudent([FromRoute] Guid id, [FromBody] UpdateStudent update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var student = await _studentRepo.updateStudent(id, update);
            if (student == null) return StatusCode(404, "Student not found");
            return Ok(student.FromStudent());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> deleteStudent([FromRoute] Guid id)
        {
            var student = await _studentRepo.deleteStudentById(id);
            if (student == null) return StatusCode(404, "Student not found");
            return Ok();
        }
    }
}