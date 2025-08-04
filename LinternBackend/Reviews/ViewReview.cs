using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Reviews
{
    public class ViewReview
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid ReviewerOrganizationId { get; set; } // optional: allow student reviews too
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}