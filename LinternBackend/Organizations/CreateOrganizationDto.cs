using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Organizations
{
    public class CreateOrganizationDto
    {
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string ContactEmail { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}