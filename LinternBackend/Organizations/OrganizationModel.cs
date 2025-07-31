using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Jobs;

namespace LinternBackend.Organizations
{
    public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
}

}