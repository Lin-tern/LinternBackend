using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Applications
{
    public class CreateApplication
    {
        public Guid StudentId { get; set; }
        public Guid JobId { get; set; }
        public string Status { get; set; } = string.Empty;
        
        public string CoverLetter { get; set; } = string.Empty;
    }
}