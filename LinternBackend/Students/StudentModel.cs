using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Applications;

namespace LinternBackend.Students
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // hashed password
        public string University { get; set; } = string.Empty;
        public string CourseOfStudy { get; set; } = string.Empty;
        public string Level { get; set; }  = string.Empty;// e.g., 200, 300 level
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string LinkedInUrl { get; set; } = string.Empty;
        public string GithubUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }

}