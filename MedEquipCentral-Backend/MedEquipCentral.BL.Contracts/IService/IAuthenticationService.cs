using FluentResults;
using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService;
public interface IAuthenticationService
{
    Task<AuthenticationTokensDto> Login(CredentialsDto credentials);
    Task<AuthenticationTokensDto> RegisterUser(UserDto userDto);
    Task<AuthenticationTokensDto> ConfirmEmailAsync(int uid);
}