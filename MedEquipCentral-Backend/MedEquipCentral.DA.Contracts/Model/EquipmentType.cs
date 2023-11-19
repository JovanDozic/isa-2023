using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class EquipmentType : Entity
    {
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
