using MedEquipCentral.DA.Contracts.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEquipCentral.DA.Contracts.Model
{
    public enum AppointmentStatus
    {
        NEW = 0,
        PROCESSED = 1,
        REJECTED = 2,
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
        public bool? IsCollected { get; set; }//NULL je kad nije rezervisan termin, FALSE kada je rezervisan, a nije preuzeta oprema i TRUE kada je rezervisan i kad je preuzeta oprema
                                              //Termin je rezervisan kad su nullable polja popunjena    
        public double Price { get; set; }
        public AppointmentStatus? Status { get; set; }

        public Appointment(DateTime startTime, int duration, int companyId, int adminId, int? buyerId, List<int>? equipmentIds, bool? isCollected, double price, AppointmentStatus? status)
        {
            StartTime = startTime.ToUniversalTime();
            Duration = duration;
            CompanyId = companyId;
            AdminId = adminId;
            BuyerId = buyerId;
            EquipmentIds = equipmentIds;
            IsCollected = isCollected;
            Price = price;
            Status = status;
        }
    }
}
