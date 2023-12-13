using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.BL.Contracts.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public int AdminId { get; set; }
        public int? BuyerId { get; set; }
        public int? EquipmentId { get; set; }
        
    }
}
