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
    [Route("company/job/jobmanagement")]

    public class JobManagementController : ControllerBase
    {

        private readonly IJobManagementRepository _jobManagementRepository;

        public JobManagementController(IJobManagementRepository jobManagementRepository)
        {
            _jobManagementRepository = jobManagementRepository;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyToJob([FromBody] JobManagement appliance)
        {
            var _appliance = await _jobManagementRepository.ApplytoJob(appliance);
            return Ok(_appliance);
        }

        [HttpGet("appliances")]
        public IActionResult ApplyToJob(Guid jobId)
        {
            var appliances =  _jobManagementRepository.GetAppliancesByJob(jobId);
            return Ok(appliances);
        }

        [HttpGet("user/appliances")]
        public IActionResult ApplyToJob(string UserId)
        {
            var appliances = _jobManagementRepository.GetAppliancesByUser(UserId);
            return Ok(appliances);
        }


    }
}
