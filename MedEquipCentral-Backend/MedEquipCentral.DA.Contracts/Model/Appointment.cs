using MedEquipCentral.DA.Contracts.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEquipCentral.DA.Contracts.Model
{
    public enum AppointmentStatus
    {
        NEW = 0,
        PROCESSED = 1,
        CANCELLED = 2,
        EXPIRED = 3,
    }

    public class Appointment : Entity
    {
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User Admin { get; set; }
        public int? BuyerId { get; set; }
        public User? Buyer { get; set; }
        public List<int>? EquipmentIds { get; set; }
        [ForeignKey("EquipmentId")]
        public List<Equipment>? Equipment { get; set; } 
        public double? Price { get; set; }
        public AppointmentStatus? Status { get; set; }

        public Appointment(DateTime startTime, int duration, int companyId, int adminId, int? buyerId, List<int>? equipmentIds, double? price, AppointmentStatus? status)
        {
            StartTime = startTime.ToUniversalTime();
            Duration = duration;
            CompanyId = companyId;
            AdminId = adminId;
            BuyerId = buyerId;
            EquipmentIds = equipmentIds;
            Price = price;
            Status = status;
        }
    }
}
