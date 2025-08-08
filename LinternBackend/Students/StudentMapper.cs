using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LinternBackend.Students
{
    public static class StudentMapper
    {
        public static Student ToStudent(this CreateStudent create)
        {
            return new Student
            {
                Email = create.Email,
                FullName = create.FullName,
                University = create.University,
                CourseOfStudy = create.CourseOfStudy,
                Level = create.Level,
                DateOfBirth = create.DateOfBirth,
                Phone = create.Phone,
                LinkedInUrl = create.LinkedInUrl,
                GithubUrl = create.GithubUrl,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public static ViewStudent FromStudent(this Student student)
        {
            return new ViewStudent
            {
                StudentId = student.StudentId,
                UserId = student.UserId,
                Email = student.Email,
                FullName = student.FullName,
                University = student.University,
                CourseOfStudy = student.CourseOfStudy,
                Level = student.Level,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                LinkedInUrl = student.LinkedInUrl,
                GithubUrl = student.GithubUrl,
                CreatedAt = student.CreatedAt,
            };
        }
    }
}