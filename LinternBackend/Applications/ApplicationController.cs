using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LinternBackend.Applications
{
    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _appRepo;
        public ApplicationController(IApplicationRepository appRepo)
        {
            _appRepo = appRepo;
        }


        [HttpGet("getall")]
        public async Task<ActionResult<List<Application>>> getAllAsync()
        {
            return await _appRepo.getAll();
        }

        [HttpGet("getbyId/{id:Guid}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] Guid id)
        {
            var application = await _appRepo.getById(id);
            if (application == null) return NotFound();
            return Ok(application);
        }

        [HttpPost("create")]
        public async Task<ActionResult> createAsync([FromBody] CreateApplication application)
        {
            var app = application.ToApplication();
            await _appRepo.create(app);
            return Ok(app);
        }
    }
}