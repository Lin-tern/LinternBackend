using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Students
{
    public class UpdateStudent
    {
        public string? FullName { get; set; }
        public string? University { get; set; }
        public string? CourseOfStudy { get; set; }
        public string? Level { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; } 
        public string? LinkedInUrl { get; set; } 
        public string? GithubUrl { get; set; }
    }
}