namespace MedEquipCentral.BL.Contracts.DTO
{
    public class QrCodeDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int? BuyerId { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string Path { get; set; }
    }
}
