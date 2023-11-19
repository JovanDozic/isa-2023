using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.DA.Contracts.IRepository
{
    public interface IEquipmentTypeRepository : IRepository<EquipmentType>
    {
        List<EquipmentType> GetAll();
    }
}
