namespace MedEquipCentral.BL.Contracts.DTO
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public EquipmentTypeDto Type { get; set; }
        public List<int> CompanyIds { get; set; }
        public List<CompanyDto> Companies { get; set; }
    }
}
