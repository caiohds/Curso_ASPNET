using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {

        IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityUser<int> usuarioIdenty = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdenty,dto.Senha);
            if (resultadoIdentity.Result.Succeeded) 
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdenty).Result;
                return Result.Ok().WithSuccess(code);
            } 
            return Result.Fail("Falha ao cadastrar o usuário!");
        }
    }
}
