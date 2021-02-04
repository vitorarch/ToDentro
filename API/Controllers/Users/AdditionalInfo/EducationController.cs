using API.DataAccess;
using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Users.AdditionalInfo
{

    [ApiController]
    //[Authorize]
    [Route("/education")]

    public class EducationController : ControllerBase
    {

        private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet("v1")]
        public IActionResult GetEducation(Guid id)
        {
            var education = _educationRepository.GetEducation(id);

            if (education == null) return BadRequest(new { error = "Educação não encontrada" });
            else return Ok(education);
        }

        [HttpGet("v1/all")]
        public IActionResult GetEducation(string cpf)
        {
            var educations = _educationRepository.GetEducations(cpf);

            if (educations == null) return BadRequest(new { error = "Educação não encontrada" });
            else return Ok(educations);
        }

        [HttpPost("v1")]
        public async Task<IActionResult> AddEducation([FromBody] Education education)
        {
            var _education = await _educationRepository.AddEducation(education);

            if (_education == null) return BadRequest(new { error = "Educação não encontrada" });
            else if (_education is string) return BadRequest(new { error = _education });
            else return Ok(_education);
        }

        [HttpPut("v1")]
        public async Task<IActionResult> EditEducation([FromBody] Education education)
        {
            var _education = await _educationRepository.EditEducation(education);

            if (_education == null) return BadRequest(new { error = "Educação não encontrada" });
            else if (_education is string) return BadRequest(new { error = _education });
            else return Ok(_education);
        }

        [HttpDelete("v1")]
        public async Task<IActionResult> DeleteEducation([FromBody] Guid id)
        {
            var _education = await _educationRepository.DeleteEducation(id);

            if (_education == false) return BadRequest(new { error = "Educação não encontrada" });
            else return Ok(_education);
        }

    }
}
