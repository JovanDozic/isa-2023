namespace MedEquipCentral.BL.Contracts.DTO
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public EquipmentTypeDto? Type { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto? Company { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
