using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Organizations
{
    public class UpdateOrganization
    {
        public string? Name { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }
    }
}