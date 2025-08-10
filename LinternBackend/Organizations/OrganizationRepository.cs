using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using LinternBackend.User;

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
    }
}