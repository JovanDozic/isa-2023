using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.DA.Contracts.Helper
{
    public class QrCode : Entity
    {
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string Path { get; set; }
    }
}
