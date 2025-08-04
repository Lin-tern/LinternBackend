using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Resumes
{
    public class UpdateResume
    {
        public Guid StudentId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
    }
}