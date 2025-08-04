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
using LinternBackend.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LinternBackend.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);

        // Application ↔ Job (many-to-1)
        builder.Entity<Application>()
            .HasOne(a => a.Job)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        // Application ↔ StudentProfile (many-to-1)
        builder.Entity<Application>()
            .HasOne(a => a.Student)
            .WithMany(s => s.Applications)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Job ↔ OrganizationProfile (many-to-1)
        builder.Entity<Job>()
            .HasOne(j => j.Organization)
            .WithMany(o => o.Jobs)
            .HasForeignKey(j => j.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Resume ↔ StudentProfile (many-to-1)
        builder.Entity<Resume>()
            .HasOne(r => r.Student)
            .WithMany(s => s.resumes)
            .HasForeignKey(r => r.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Review ↔ Application (1-to-1)
        builder.Entity<Review>()
            .HasOne(r => r.Application)
            .WithOne(a => a.review)
            .HasForeignKey<Review>(r => r.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<Review>()
            .HasOne(r => r.ReviewerOrganization)
            .WithOne(a => a.review)
            .HasForeignKey<Review>(r => r.ReviewerOrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Skill ↔ Student (many-to-many via StudentSkill)
            builder.Entity<StudentSkill>()
            .HasKey(ss => new { ss.StudentId, ss.SkillId });

        builder.Entity<StudentSkill>()
            .HasOne(ss => ss.Student)
            .WithMany(s => s.studentSkills)
            .HasForeignKey(ss => ss.StudentId);

        builder.Entity<StudentSkill>()
            .HasOne(ss => ss.Skill)
            .WithMany(s => s.StudentSkills)
            .HasForeignKey(ss => ss.SkillId);

        // AppUser ↔ StudentProfile (1-to-1)
        builder.Entity<Student>()
            .HasOne(sp => sp.appUser)
            .WithOne(u => u.student)
            .HasForeignKey<Student>(sp => sp.UserId);

        // AppUser ↔ OrganizationProfile (1-to-1)
        builder.Entity<Organization>()
            .HasOne(op => op.appUser)
            .WithOne(u => u.organization)
            .HasForeignKey<Organization>(op => op.UserId);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }

}