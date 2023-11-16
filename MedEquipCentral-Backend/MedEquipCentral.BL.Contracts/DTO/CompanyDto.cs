#nullable disable

namespace MedEquipCentral.BL.Contracts.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationDto Location { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        // TODO: Lista terminaDto
        public List<UserDto> CompanyAdmins { get; set; }
    }
}
