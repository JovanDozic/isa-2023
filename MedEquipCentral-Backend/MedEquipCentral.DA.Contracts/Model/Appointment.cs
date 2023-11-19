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
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public int CompanyId { get; set; }
        public string? Date { get; set; }

        public Appointment(int userId, int equipmentId, string? date)
        {
            UserId = userId;
            EquipmentId = equipmentId;
            Date = date;
        }

    }
}
