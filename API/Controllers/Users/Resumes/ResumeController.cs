using API.Interfaces.Users.Resumes;
using API.Models.Users.Resumes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Users.Resumes
{

    [ApiController]
    //[Authorize]
    [Route("/user/resume")]

    public class ResumeController : ControllerBase
    {

        private readonly IResumeRepository _resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> GetUserResume([FromForm]Guid id)
        {
            var resume = await _resumeRepository.GetResume(id);

            if (resume == null) return BadRequest(new { error = "Currículo não encontrado" });
            else return Ok(resume);
        }

        [HttpPost("v1")]
        public async Task<IActionResult> AddResume([FromBody] Resume resume)
        {
            var _resume = await _resumeRepository.AddResume(resume);

            if (_resume == null) return BadRequest(new { error = "Currículo não encontrado" });
            else return Ok(_resume);
        }

        [HttpPut("v1")]
        public async Task<IActionResult> EditResume([FromBody] Resume resume)
        {
            var _resume = await _resumeRepository.EditResume(resume);

            if (_resume == null) return BadRequest(new { error = "Currículo não encontrado" });
            else if(_resume is string) return BadRequest(new { error = _resume });
            else return Ok(_resume);
        }

    }
}
