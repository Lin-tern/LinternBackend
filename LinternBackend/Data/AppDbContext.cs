using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Applications;
using LinternBackend.Jobs;
using LinternBackend.Organizations;
using LinternBackend.Resumes;
using LinternBackend.Reviews;
using LinternBackend.Skills;
using LinternBackend.Students;
using LinternBackend.StudentSkills;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinternBackend.Data
{
    public class AppDbContext : IdentityDbContext<Student>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

}