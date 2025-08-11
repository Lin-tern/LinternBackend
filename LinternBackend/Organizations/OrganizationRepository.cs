using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using LinternBackend.User;
using Microsoft.EntityFrameworkCore;

namespace LinternBackend.Organizations
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepo;

        public OrganizationRepository(
            AppDbContext context,
            IUserRepository userRepo
        )
        {
            _context = context;
            _userRepo = userRepo;
        }
        
        public async Task<(Organization? organization, string? text)> createOrganization(Organization organization, string password)
        {
            var user = await _userRepo.createUser(organization.ContactEmail, password);

            if (user.User == null) return (null, $"{user.ErrorMessage}");
            organization.UserId = user.User.Id;
            user.User.Type = "Organization"; 
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();
            return (organization, "null");
        }

        public async Task<Organization?> deletOrganization(Guid id)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.OrganizationId == id);
            if (organization == null) return null;

            await _userRepo.deleteUser(organization.UserId);

            return organization;
        }

        public async Task<List<Organization>> getAll()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task<Organization?> GetbyId(Guid id)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.OrganizationId == id);
            if (organization == null) return null;
            return organization;
        }

        public async Task<Organization?> updateOrganization(Guid id, UpdateOrganization update)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.OrganizationId == id);
            if (organization == null) return null;

            if (update.Name != null) organization.Name = update.Name;
            if (update.Industry != null) organization.Industry = update.Industry;
            if (update.WebsiteUrl != null) organization.WebsiteUrl = update.WebsiteUrl;
            if (update.LogoUrl != null) organization.LogoUrl = update.LogoUrl;


            await _context.SaveChangesAsync();
            return organization;
        }
    }
}