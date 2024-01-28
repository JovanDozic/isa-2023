using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers;

[Route("api/users")]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    [EnableCors("_mySpecificOrigins")]
    [AllowAnonymous]
    public async Task<AuthenticationTokensDto> RegisterUser([FromBody] UserDto user)
    { 
        return await _authenticationService.RegisterUser(user);
    }

    [HttpPatch("verify/{userId:int}")]
    [Authorize(Policy = "authenticatedPolicy")]
    public async Task<AuthenticationTokensDto> VerifyUser([FromRoute]int userId)
    {
        return await _authenticationService.ConfirmEmailAsync(userId);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthenticationTokensDto>> Login([FromBody] CredentialsDto credentials)
    {
        var token = await _authenticationService.Login(credentials);

        if (token != null)
        {
            return Ok(token);
        }

        return NotFound(new { message = "Invalid credentials" });
    }
}