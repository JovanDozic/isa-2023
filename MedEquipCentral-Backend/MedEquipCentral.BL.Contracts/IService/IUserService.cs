using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<List<UserDto>> GetCompanyAdmins(int companyId);
        Task RemoveFromCompany(int userId);
        Task AddToCompany(int userId, int companyId);
        Task<List<UserDto>> GetAllRegistered();
    }
}
