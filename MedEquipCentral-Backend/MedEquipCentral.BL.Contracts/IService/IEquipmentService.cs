using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IEquipmentService
    {
        Task<List<EquipmentDto>> GetAllForCompany(int companyId);
        List<EquipmentDto> GetAll();
    }
}
