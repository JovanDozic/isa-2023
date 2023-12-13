using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class Equipment : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public EquipmentType Type { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public Equipment(string name, string description, int typeId, int companyId)
        {
            Name = name;
            Description = description;
            TypeId = typeId;
            Type = new();
            CompanyId = companyId;
            Company = new Company();
        }
    }
}
