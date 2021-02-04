using API.Interfaces.Companies.Jobs.AdditionalInfo;
using API.Models.Companies.Jobs.AdditionalInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Companies.Jobs.AddtionalInfo
{

    [ApiController]
    [Authorize]
    [Route("company/job/requirements")]

    public class RequirementsController : ControllerBase
    {

        private readonly IRequirementRepository _requirementRepository;

        public RequirementsController(IRequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }


        [HttpGet("v1")]
        public IActionResult GetRequirement(Guid jobId)
        {
            var Requirements = _requirementRepository.GetRequirementsByJob(jobId);

            if (Requirements == null) return NotFound("Requisitos não encontrados");
            else return Ok(Requirements);
        }

        [HttpGet("v1")]
        public IActionResult GetRequirementById(Guid id)
        {
            var Requirement = _requirementRepository.GetRequirementsByJob(id);

            if (Requirement == null) return NotFound("Requisito não encontrado");
            else return Ok(Requirement);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddRequirement([FromBody] Requirement requirement)
        {
            var _requirement = await _requirementRepository.AddRequirement(requirement);

            if (_requirement == null) return NotFound("Requisito não encontrado");
            else return Ok(_requirement);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditRequirement([FromBody] Requirement requirement)
        {
            var _requirement = await _requirementRepository.EditRequirement(requirement);

            if (_requirement == null) return NotFound("Requisito não encontrado");
            else return Ok(_requirement);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeleteRequirement([FromBody] Guid id)
        {
            var _requirement = await _requirementRepository.DeleteRequirement(id);

            if (_requirement == false) return NotFound("Requisito não encontrado");
            else return Ok(_requirement);
        }

    }
}
