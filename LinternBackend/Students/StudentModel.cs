using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Applications;
using LinternBackend.Resumes;
using LinternBackend.StudentSkills;
using LinternBackend.User;

namespace LinternBackend.Students
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string UserId { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string CourseOfStudy { get; set; } = string.Empty;
        public string Level { get; set; }  = string.Empty;// e.g., 200, 300 level
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string LinkedInUrl { get; set; } = string.Empty;
        public string GithubUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        
        public AppUser appUser { get; set; } = new AppUser();
        public ICollection<StudentSkill> studentSkills { get; set; } = new List<StudentSkill>();
        public ICollection<Resume> resumes { get; set; } = new List<Resume>();
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }

}