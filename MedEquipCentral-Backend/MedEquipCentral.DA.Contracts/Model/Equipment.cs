using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class Equipment : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public EquipmentType Type { get; set; }
        public List<int> CompanyIds { get; set; }
        public List<Company> Companies { get; set; }

        public Equipment(/*string name, string description, int typeId, int companyId*/)
        {
            //Name = name;
            //Description = description;
            //TypeId = typeId;
            Type = new();
            CompanyIds = new();
            Companies = new();
            //Validate();
        }

        private void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
