using API.Interfaces.Companies.Jobs;
using API.Models.Companies.Jobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Companies.Jobs
{

    [ApiController]
    [Authorize]
    [Route("company/job")]

    public class JobController : ControllerBase
    {

        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var job = await _jobRepository.GetJob(id);

            if (job == null) return NotFound("Vaga não encontrada");
            else return Ok(job);
        }

        [HttpGet("v1/company/{id}")]
        public IActionResult GetJobByCompany(string id)
        {
            var job = _jobRepository.GetJobsByCompany(id);

            if (job == null) return NotFound("Vagas não encontradas");
            else return Ok(job);
        }

        [HttpGet("v1/all")]
        public IActionResult GetAllJobs()
        {
            var job = _jobRepository.GetAllJobs();

            if (job == null) return NotFound("Vagas não encontradsa");
            else return Ok(job);
        }

        [HttpPost("v1")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            var _job = await _jobRepository.AddJob(job);

            if (_job is string) return BadRequest(new { error = _job });
            else return Ok(_job);
        }

        [HttpPut("v1")]
        public async Task<IActionResult> EditJob([FromBody] Job job)
        {
            var _job = await _jobRepository.EditJob(job);

            if (_job == null) return NotFound("Vaga não encontrada");
            else return Ok(_job);
        }

        [HttpDelete("v1/{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var job = await _jobRepository.DeleteJob(id);

            if (job == false) return NotFound("Vaga não encontrada");
            else return Ok(job);
        }

    }
}
