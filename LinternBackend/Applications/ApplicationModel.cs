using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Jobs;
using LinternBackend.Reviews;
using LinternBackend.Students;

namespace LinternBackend.Applications
{
    public class Application
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid JobId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string CoverLetter { get; set; } = string.Empty;
        public DateTime AppliedAt { get; set; }

        public Student Student { get; set; } = new Student();
        public Job Job { get; set; } = new Job();
        public Review review { get; set; } = new Review();
    }

}