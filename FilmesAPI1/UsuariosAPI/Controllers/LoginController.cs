using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogarUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }
        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenha(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenha(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }
        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenha(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaSenha(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }

    }
}
