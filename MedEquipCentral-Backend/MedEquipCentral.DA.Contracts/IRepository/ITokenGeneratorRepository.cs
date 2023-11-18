using FluentResults;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.DA.Contracts.IRepository;
public interface ITokenGeneratorRepository
{
    Task<AuthenticationTokensDto> GenerateAccessToken(User user);
}