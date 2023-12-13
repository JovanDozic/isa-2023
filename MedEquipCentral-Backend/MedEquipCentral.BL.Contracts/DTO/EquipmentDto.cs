﻿namespace MedEquipCentral.BL.Contracts.DTO
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentTypeDto Type { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
