using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IEquipmentService
    {
        Task<List<EquipmentDto>> GetAllForCompany(int companyId);
        List<EquipmentDto> GetAll();
        Task<PagedResult<EquipmentDto>> Search(EquipmentPagedIn dataIn);
        Task<EquipmentDto> Add(EquipmentDto equipmentDto);
        Task<EquipmentDto> Update(EquipmentDto equipmentDto);
        Task<bool> Delete(int equipmentId);
        Task<EquipmentDto> GetById(int equipmentId);
        Task<List<EquipmentDto>> ReduceQuantity(int appointmentId);
        Task<bool> StartDelivery();
        List<string> GetMessage();
    }
}
