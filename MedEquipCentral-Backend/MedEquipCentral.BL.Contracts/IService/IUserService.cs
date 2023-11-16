using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
    }
}
