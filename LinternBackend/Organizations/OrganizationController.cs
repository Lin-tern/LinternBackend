using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.User;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.Organizations
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organRepo;
        private readonly IUserRepository _userRepo;

        public OrganizationController(IOrganizationRepository organRepo, IUserRepository userRepo)
        {
            _organRepo = organRepo;
            _userRepo = userRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationDto create)
        {
            var organization = create.ToOrganization();
            var result = await _organRepo.createOrganization(organization, create.Password);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var token = await _userRepo.token(result.organization.UserId);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok( new
            {
                ViewStudent = result.organization?.FromOrganization(),
                token = token
                }
                );
        }
    }
}