using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Students;

namespace LinternBackend.Resumes
{
    public class Resume
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }

        public Student Student { get; set; } = new Student();
    }

}