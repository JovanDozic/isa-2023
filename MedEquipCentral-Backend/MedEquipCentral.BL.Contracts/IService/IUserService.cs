using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<List<UserDto>> GetCompanyAdmins(int companyId);
        Task<UserDto> Update(UserDto user);
        Task RemoveFromCompany(int userId);
        Task AddToCompany(int userId, int companyId);
        Task<List<UserDto>> GetAllRegistered();
        Task<List<UserDto>> GetOtherCompanyAdmins(int companyId, int adminId);
        Task AddSystemAdmin(int userId);
        Task RemoveSystemAdmin(int userId);
        Task<List<UserDto>> GetAllSystemAdmins();
        Task ChangePassword(int id, string newPassword);
        Task<List<UserDto>> GetUsersWithReservation(int companyId);
        Task<List<UserDto>> PenalizeUncollectedAppointments(int adminId);
        Task<int> GetPenalPoints(int userId);
    }
}
