#nullable disable

namespace MedEquipCentral.BL.Contracts.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // public List<UserDto> CompanyAdmins { get; set; }
    }
}
