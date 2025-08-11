using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.Jobs
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepo;
        public JobController(IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createjob(CreateJob create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var job = create.ToJob();
            await _jobRepo.createJobAsync(job);
            return Ok(job.FromJob());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAllAync()
        {
            return Ok(await _jobRepo.GetAllJobsAsync());
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var job = await _jobRepo.GetJobByIdAsync(id);
            if (job == null) return StatusCode(404, "Job not found");
            return Ok(job.FromJob());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> updatejob([FromRoute] Guid id, [FromBody] UpdateJob update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var job = await _jobRepo.updateJobAsync(id, update);
            if (job == null) return StatusCode(404, "Job not found");
            return Ok(job.FromJob());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> deletejob([FromRoute] Guid id)
        {
            var job = await _jobRepo.deleteJobAsync(id);
            if (job == null) return StatusCode(404, "Job not found");
            return Ok();
        }
    }
}