using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {

            return Ok();
        }
    }
}
