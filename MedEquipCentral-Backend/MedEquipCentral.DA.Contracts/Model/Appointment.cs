using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<int>? EquipmentIds { get; set; }
        [ForeignKey("EquipmentId")]
        public List<Equipment>? Equipment { get; set; }

        public Appointment(DateTime startTime, int duration, string adminName, string adminSurname, int adminId, int companyId, List<int> equipmentIds)
        {
            StartTime = startTime.ToUniversalTime();
            Duration = duration;
            AdminName = adminName;
            AdminSurname = adminSurname;
            AdminId = adminId;
            CompanyId = companyId;
            EquipmentIds = equipmentIds;
            Equipment = new List<Equipment>();
        }

    }
}
