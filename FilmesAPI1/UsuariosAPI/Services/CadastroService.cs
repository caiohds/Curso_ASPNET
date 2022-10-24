using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {

        IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityUser<int> usuarioIdenty = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdenty,dto.Senha);
            if (resultadoIdentity.Result.Succeeded) 
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdenty).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[] {usuarioIdenty.Email}, "Link de Ativação", usuarioIdenty.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            } 
            return Result.Fail("Falha ao cadastrar o usuário!");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(usuario => usuario.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.codigoDeAtivacao).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuário!");
        }
    }
}
