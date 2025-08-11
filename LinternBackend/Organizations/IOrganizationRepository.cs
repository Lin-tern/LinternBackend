using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Organizations
{
    public interface IOrganizationRepository
    {
        public Task<(Organization? organization, string? text)> createOrganization(Organization organization, string password);
        public Task<Organization?> GetbyId(Guid id);
        public Task<List<Organization>> getAll();
        public Task<Organization?> updateOrganization(Guid id, UpdateOrganization update);
        public Task<Organization?> deletOrganization (Guid id);
    }
}