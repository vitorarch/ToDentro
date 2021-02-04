using API.Interfaces.Users;
using API.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Users
{

    [ApiController]
    //[Authorize]
    [Route("/user/profile")]

    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepsoitory;

        public UserController(IUserRepository userRepsoitory)
        {
            _userRepsoitory = userRepsoitory;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> GetProfile([FromForm] string CPF)
        {
            var profile = await _userRepsoitory.GetUserProfile(CPF);
            if (profile == null) return BadRequest(new { error = "Usuário não encontrado" });
            return Ok(profile);
        }

        [HttpPut("v1")]
        public async Task<IActionResult> EditProfile([FromBody] User user)
        {
            var _user = await _userRepsoitory.EditUserProfile(user);
            
            if (_user == null) return BadRequest(new { error = "Usuário não encontrado" });
            else if (_user is string) return BadRequest(new { error = _user });
            else return Ok(_user);
        }

        [HttpDelete("v1")]
        public async Task<IActionResult> DeleteProfile([FromForm] string cpf)
        {
            var _user = await _userRepsoitory.DeleteUserProfile(cpf);
            
            if (_user == false) return BadRequest(new { error = "Usuário não encontrado" });
            else return Ok(new { message = "Usuário deletado" });
        }

    }

}
