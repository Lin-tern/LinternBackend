using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.Resumes
{
    [ApiController]
    [Route("api/resume")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _resumeRepo;

        public ResumeController(IResumeRepository resumeRepo)
        {
            _resumeRepo = resumeRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateResume create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var resume = create.ToResume();
            var result = await _resumeRepo.createAsync(resume);
            return Ok(result.FromResume());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _resumeRepo.GetAllAsync());
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var resume = await _resumeRepo.GetById(id);
            if (resume == null) return BadRequest("Not Found");
            return Ok(resume.FromResume());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateResume update)
        {
            var resume = await _resumeRepo.updateAsync(id, update);
            if (resume == null) return BadRequest("Resume does not exist");
            return Ok(resume.FromResume());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> deleteById([FromRoute] Guid id)
        {
            var resume = await _resumeRepo.deleteAsync(id);
            if (resume == null) return BadRequest("Resume does not exist");
            return Ok();
        }
    }
}