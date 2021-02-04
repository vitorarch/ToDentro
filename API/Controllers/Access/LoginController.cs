using API.Interfaces.Access;
using API.Models.Users;
using API.Repositories.Access;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Access
{
    [ApiController]
    [Route("/login")]

    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string cpf, [FromForm] string password)
        {
            var _user = await _loginRepository.SingingIn(cpf, password);

            if (_user == null) return BadRequest( new { error = "Usuário não encontrado" });
            else return Ok(_user);
        }

    }
}
