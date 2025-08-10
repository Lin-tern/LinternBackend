using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using LinternBackend.User;

namespace LinternBackend.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepo;
        public StudentRepository(AppDbContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }
        public async Task<(Student? student, string? text)> createStudentAsync(Student student, string password)
        {
            var user = await _userRepo.createUser(student.Email, password);
            if (user.User == null) return (null, $"{user.ErrorMessage}");
            student.UserId = user.User.Id;
            user.User.Type = "Student";
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return (student, "null");
        }

        public async Task<Student?> deleteStudentById(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null) return null;
            
            await _userRepo.deleteUser(student.UserId);

            return student;
        }

        public async Task<List<Student>> getAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> getStudentById(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null) return null;
            return student;
        }

        public async Task<Student?> updateStudent(Guid id, UpdateStudent update)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null) return null;

            if (update.FullName != null) student.FullName = update.FullName;
            if (update.University != null) student.University = update.University;
            if (update.CourseOfStudy != null) student.CourseOfStudy = update.CourseOfStudy;
            if (update.Level != null) student.Level = update.Level;
            if (update.DateOfBirth != null) student.DateOfBirth = update.DateOfBirth;
            if (update.Phone != null) student.Phone = update.Phone;
            if (update.LinkedInUrl != null) student.LinkedInUrl = update.LinkedInUrl;
            if (update.GithubUrl != null) student.GithubUrl = update.GithubUrl;

            await _context.SaveChangesAsync();
            return student;
        }
    }
}