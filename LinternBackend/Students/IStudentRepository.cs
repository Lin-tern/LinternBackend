using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Students
{
    public interface IStudentRepository
    {
        public Task<(Student? student, string? text)> createStudentAsync(Student student, string password);
        public Task<List<Student>> getAll();
        public Task<Student?> getStudentById(Guid id);
        public Task<Student?> updateStudent(Guid id, UpdateStudent update);
        public Task<Student?> deleteStudentById(Guid id);
    }
}