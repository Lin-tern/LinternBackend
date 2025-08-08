using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Organizations
{
    public static class OrganizationMapper
    {
        public static Organization ToOrganization(this CreateOrganizationDto create)
        {
            return new Organization
            {
                Name = create.Name,
                ContactEmail = create.ContactEmail,
                Industry = create.Industry,
                WebsiteUrl = create.WebsiteUrl,
                LogoUrl = create.LogoUrl,
            };
        }

        public static ViewOrganization FromOrganization(this Organization organization)
        {
            return new ViewOrganization
            {
                OrganizationId = organization.OrganizationId,
                UserId = organization.UserId,
                Name = organization.Name,
                ContactEmail = organization.ContactEmail,
                Industry = organization.Industry,
                WebsiteUrl = organization.WebsiteUrl,
                LogoUrl = organization.LogoUrl,
            };
        }
    }
}