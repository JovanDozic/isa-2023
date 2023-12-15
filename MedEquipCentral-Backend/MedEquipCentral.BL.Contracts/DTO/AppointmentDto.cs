#nullable disable

namespace MedEquipCentral.BL.Contracts.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public int AdminId { get; set; }
        public int? BuyerId { get; set; }
        public UserDto? Buyer { get; set; }
        public List<int>? EquipmentIds { get; set; }

    }
}
