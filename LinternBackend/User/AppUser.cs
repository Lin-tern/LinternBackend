using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Organizations;
using LinternBackend.Students;
using Microsoft.AspNetCore.Identity;


namespace LinternBackend.User
{
    public class AppUser : IdentityUser
    {
        public string Type { get; set; } = string.Empty;

        public Student? student { get; set; }
        public Organization? organization { get; set; }
    }
}