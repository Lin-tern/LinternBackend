using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Applications;
using LinternBackend.Organizations;

namespace LinternBackend.Reviews
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid ReviewerOrganizationId { get; set; } // optional: allow student reviews too
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; } // e.g., 1 to 5
        public DateTime CreatedAt { get; set; }

        public Application Application { get; set; } = new Application();
        public Organization ReviewerOrganization { get; set; } = new Organization();
    }

}