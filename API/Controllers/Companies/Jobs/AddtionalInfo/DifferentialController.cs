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
    [Route("company/job/differential")]

    public class DifferentialController : ControllerBase
    {

        private readonly IDifferentialRepository _differentialRepository;

        public DifferentialController(IDifferentialRepository differentialRepository)
        {
            _differentialRepository = differentialRepository;
        }

        [HttpGet("v1")]
        public IActionResult GetDifferential(Guid jobId)
        {
            var differentialsList = _differentialRepository.GetDifferentialsByJob(jobId);

            if (differentialsList == null) return NotFound("Você ainda não adicioanou diferencias para esta");
            else return Ok(differentialsList);
        }

        [HttpGet("v1")]
        public IActionResult GetDifferentialById(Guid id)
        {
            var differential = _differentialRepository.GetDifferentialById(id);

            if (differential == null) return NotFound("Diferencial não encontrado");
            else return Ok(differential);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddDifferential([FromBody] Differential differential)
        {
            var _differential = await _differentialRepository.AddDifferential(differential);

            if (_differential == null) return NotFound("Diferencial não encontrado");
            else return Ok(_differential);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditDifferential([FromBody] Differential differential)
        {
            var _differential = await _differentialRepository.EditDifferential(differential);

            if (_differential == null) return NotFound("Diferencial não encontrado");
            else return Ok(_differential);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeleteDifferential([FromBody] Guid id)
        {
            var _differential = await _differentialRepository.DeleteDifferential(id);

            if (_differential == false) return NotFound("Diferencial não encontrado");
            else return Ok(_differential);
        }

    }
}
