#nullable disable

using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class Company : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        
        // TODO: Lista termina i Radno vreme
    }
}
