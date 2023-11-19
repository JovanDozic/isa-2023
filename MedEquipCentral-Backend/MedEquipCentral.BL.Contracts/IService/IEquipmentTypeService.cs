using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IEquipmentTypeService
    {
        List<EquipmentTypeDto> GetAll();
    }
}
