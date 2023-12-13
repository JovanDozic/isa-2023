using MedEquipCentral.DA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class Appointment : Entity
    {
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public int AdminId { get; set; }
        public int? BuyerId { get; set; }
        public int? EquipmentId { get; set; }

        public Appointment(DateTime startTime, int duration, string adminName, string adminSurname, int adminId, int companyId)
        {
            StartTime = startTime.ToUniversalTime();
            Duration = duration;
            AdminName = adminName;
            AdminSurname = adminSurname;
            AdminId = adminId;
            CompanyId = companyId;
        }

    }
}
