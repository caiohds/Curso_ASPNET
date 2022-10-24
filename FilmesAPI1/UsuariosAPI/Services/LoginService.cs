using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Senha,false,false);
            if (resultadoIdentity.Result.Succeeded) 
            {
                var identityUser = _signInManager.UserManager.Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName ==  request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Falhou");
        }

        public Result SolicitaResetSenha(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = _signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());
            if(identityUser == null)
            {
                return Result.Fail("Email não cadastrado no sistema!");
            }
            string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
            return Result.Ok().WithSuccess(codigoDeRecuperacao);
        }
    }
}
