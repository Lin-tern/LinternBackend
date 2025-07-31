using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Jobs;
using LinternBackend.Students;

namespace LinternBackend.Applications
{
    public class Application
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; } = string.Empty;// e.g., Pending, Accepted, Rejected
        public string CoverLetter { get; set; } = string.Empty;
        public DateTime AppliedAt { get; set; }

        public Student Student { get; set; } = new Student();
        public Job Job { get; set; } = new Job();
    }

}