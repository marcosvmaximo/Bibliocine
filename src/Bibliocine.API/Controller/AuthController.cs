using Bibliocine.API.Controller.Common;
using Bibliocine.Business.Entities;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.Business.ViewModels;
using Bibliocine.Core.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bibliocine.API.Controller;

[Route("v1/conta")]
public class AuthController : CommonController
{
    private readonly SignInManager<Usuario> _signInUser;
    private readonly UserManager<Usuario> _userManager;

    public AuthController(
        INotifyHandler notifyHandler,
        SignInManager<Usuario> signInUser,
        UserManager<Usuario> userManager) : base(notifyHandler)
    {
        _signInUser = signInUser;
        _userManager = userManager;
    }

    [HttpPost("registrar")]
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
        return await CustomResponse(new { Username = request.Email, Name = request.Nome});
    }

    [HttpPost("logar")]
    public async Task<ActionResult> Logar([FromBody] LogarUsuarioViewModel request)
    {
        if (!ModelState.IsValid)
            return await CustomResponse(ModelState);

        var result = await _signInUser.PasswordSignInAsync(request.Email, request.Senha, false, true);

        if (result.Succeeded)
        {
            return await CustomResponse();
        }
        if (result.IsLockedOut)
        {
            await Notify("Usuário bloqueado.");
            return await CustomResponse();
        }
        
        await Notify("Usuário ou senha inválido.");
        return await CustomResponse();
    }
}