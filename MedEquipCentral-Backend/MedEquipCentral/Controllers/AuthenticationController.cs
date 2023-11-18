using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace MedEquipCentral.Controllers;

[Route("api/users")]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IEmailService _emailService;

    public AuthenticationController(IAuthenticationService authenticationService, IEmailService emailService)
    {
        _authenticationService = authenticationService;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<AuthenticationTokensDto> RegisterUser([FromBody] UserDto user)
    {
        try 
        {
            return await _authenticationService.RegisterUser(user);
        } catch (Exception ex)
        {
            throw new Exception("User already exists.");
        }
    }

    [HttpGet("registred")]
    public async Task<AuthenticationTokensDto> RegistredUser(string uid, string token, string email)
    {
        return await _authenticationService.ConfirmEmailAsync(Convert.ToInt32(uid), token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] CredentialsDto credentials)
    {
        var token = await _authenticationService.Login(credentials);
        if(token != null) 
        {
            return Ok(new {token});
        }
        return BadRequest(new { message = "Username or password is incorrect"});
    }
}