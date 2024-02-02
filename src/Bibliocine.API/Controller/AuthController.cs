using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Bibliocine.API.Configurations;
using Bibliocine.API.Configurations.Auth;
using Bibliocine.API.Controller.Common;
using Bibliocine.Business.Entities;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.Business.ViewModels;
using Bibliocine.Core.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bibliocine.API.Controller;

[Route("api/v1/conta")]
public class AuthController : CommonController
{
    private readonly SignInManager<Usuario> _signInUser;
    private readonly UserManager<Usuario> _userManager;
    private readonly IdentityConfig _identityConfig;

    public AuthController(
        INotifyHandler notifyHandler,
        IOptions<IdentityConfig> identityConfig,
        SignInManager<Usuario> signInUser,
        UserManager<Usuario> userManager) : base(notifyHandler)
    {
        _identityConfig = identityConfig.Value; 
        _signInUser = signInUser;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Registrar([FromBody] RegistrarUsuarioViewModel request)
    {
        if (!ModelState.IsValid)
            return await CustomResponse(ModelState);

        Usuario user = new(request.Nome, request.DataNascimento)
        {
            UserName = request.Email,
            Email = request.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Senha);
        
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                await Notify(error.Description);
            }
        
            return await CustomResponse(result.Errors);
        }

        await _signInUser.SignInAsync(user, false);
        
        return await CustomResponse(new
        {
            User = new
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email
            },
            ExpiresIn = _identityConfig.ExpiracaoHoras,
            Token = GerarJwt()
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Logar([FromBody] LogarUsuarioViewModel request)
    {
        if (!ModelState.IsValid)
            return await CustomResponse(ModelState);

        var result = await _signInUser.PasswordSignInAsync(request.Email, request.Senha, false, true);
        
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            return await CustomResponse(new
            {
                User = new
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email
                },
                ExpiresIn = _identityConfig.ExpiracaoHoras,
                Token = GerarJwt(),
            });
        }
        if (result.IsLockedOut)
        {
            await Notify("Usuário bloqueado.");
            return await CustomResponse();
        }
        
        await Notify("Usuário ou senha inválido.");
        return await CustomResponse();
    }

    private string GerarJwt()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_identityConfig.Secret);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
        {
            Issuer = _identityConfig.Emissor,
            Audience = _identityConfig.ValidoEm,
            Expires = DateTime.UtcNow.AddHours(_identityConfig.ExpiracaoHoras),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        });

        var encondedToken = tokenHandler.WriteToken(token);
        return encondedToken;
    }
}