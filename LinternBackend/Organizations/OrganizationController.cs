using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return Ok(new
            {
                ViewStudent = result.organization?.FromOrganization(),
                token = token
            }
                );
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getall()
        {
            return Ok(await _organRepo.getAll());
        }

        [HttpGet("getby/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var organization = await _organRepo.GetbyId(id);
            if (organization == null) return NotFound();
            return Ok(organization.FromOrganization());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateOrganization update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var organization = await _organRepo.updateOrganization(id, update);
            if (organization == null) return StatusCode(404, "Organization not found");
            return Ok(organization.FromOrganization());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> deleteById(Guid id)
        {
            var organization = await _organRepo.deletOrganization(id);

            if (organization == null) return NotFound();

            return Ok();
        }
    }
}