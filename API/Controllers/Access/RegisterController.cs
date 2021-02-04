using API.Interfaces.Access;
using API.Models.Companies;
using API.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Access
{
    [ApiController]
    [Route("register")]

    public class RegisterController : ControllerBase
    {

        private readonly IRegisterRepository _registerRepository;

        public RegisterController(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpPost("user")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            var result = await _registerRepository.SingingUp(user);

            if (result is User) return Ok(user);
            return BadRequest( new { error = result });
        }

        [HttpPost("company")]
        public async Task<IActionResult> RegisterCompany([FromBody] Company company)
        {
            var result = await _registerRepository.SingingUp(company);

            if (result is Company) return Ok(company);
            return BadRequest(new { error = result });
        }
    }
}
