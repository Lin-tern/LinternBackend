using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Students;

namespace LinternBackend.Resumes
{
    public class Resume
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }

        public Student Student { get; set; } = new Student();
    }

}