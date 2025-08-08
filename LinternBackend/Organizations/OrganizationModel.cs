using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Jobs;
using LinternBackend.Reviews;
using LinternBackend.User;

namespace LinternBackend.Organizations
{
    public class Organization 
    {
        [Key]
        public Guid OrganizationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public AppUser? appUser { get; set; }
        public Review? review { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }

}