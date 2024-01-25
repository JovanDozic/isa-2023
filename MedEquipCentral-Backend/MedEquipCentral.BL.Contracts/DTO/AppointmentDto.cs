#nullable disable

namespace MedEquipCentral.BL.Contracts.DTO
{
    public enum AppointmentStatus
    {
        NEW = 0,
        PROCESSED = 1,
        REJECTED = 2,
        EXPIRED = 3,
    }

    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public int AdminId { get; set; }
        public UserDto Admin { get; set; }
        public int? BuyerId { get; set; }
        public UserDto? Buyer { get; set; }
        public List<int>? EquipmentIds { get; set; }
        public List<EquipmentDto>? Equipment { get; set; }
        public bool? IsCollected { get; set; }
        public double Price { get; set; }
        public AppointmentStatus? Status { get; set; }
    }
}
