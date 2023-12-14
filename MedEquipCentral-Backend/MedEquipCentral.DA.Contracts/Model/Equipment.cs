using MedEquipCentral.DA.Contracts.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class Equipment : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Required]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public EquipmentType Type { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int Quantity { get; set; }

        public Equipment(string name, string description, int typeId, int companyId, int quantity)
        {
            Name = name;
            Description = description;
            TypeId = typeId;
            Type = new();
            CompanyId = companyId;
            Company = new Company();
            Quantity = quantity;
        }
    }
}
