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
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Senha, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser,
                    _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Falhou");
        }

        public Result SolicitaResetSenha(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser == null)
            {
                return Result.Fail("Email não cadastrado no sistema!");
            }
            string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
            return Result.Ok().WithSuccess(codigoDeRecuperacao);
        }



        public Result ResetaSenha(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult resultadoIdentity = _signInManager.UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Senha).Result;
            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro na operação");
        }
        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }
    }
}
