using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.DA.Contracts.IRepository
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<List<Equipment>> GetAllForCompany(int companyId);
        List<Equipment> GetAll();
        Task<List<Equipment>> GetAllBySearch(EquipmentPagedIn dataIn);
        Task<bool> Delete(int equipmentId);
    }
}
