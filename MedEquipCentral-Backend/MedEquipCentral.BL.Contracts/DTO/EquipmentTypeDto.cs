namespace MedEquipCentral.BL.Contracts.DTO
{
    public class EquipmentTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
