using System;
using System.Collections.Generic;
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
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return (student, "null");
        }
    }
}