using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
    [EnableCors("_mySpecificOrigins")]
    public async Task<AuthenticationTokensDto> RegisterUser([FromBody] UserDto user)
    { 
        return await _authenticationService.RegisterUser(user);
    }

    [HttpPatch("registred/{userId:int}")]
    public async Task<AuthenticationTokensDto> RegistredUser([FromRoute]int userId)
    {
        return await _authenticationService.ConfirmEmailAsync(userId);
    }

    [HttpPost("login")]
    public async Task<AuthenticationTokensDto?> Login([FromBody] CredentialsDto credentials)
    {
        var token = await _authenticationService.Login(credentials);
        if(token != null) 
        {
            return token;
        }
        return null;
    }
}