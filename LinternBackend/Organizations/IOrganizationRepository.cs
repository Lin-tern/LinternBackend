using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Organizations
{
    public interface IOrganizationRepository
    {
        public Task<(Organization? organization, string? text)> createOrganization(Organization organization, string password); 
    }
}