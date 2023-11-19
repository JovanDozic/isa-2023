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
        public DateTime? Date { get; set; }

        public Appointment(int userId, int equipmentId, DateTime? date)
        {
            UserId = userId;
            EquipmentId = equipmentId;
            Date = date;
            //Validate();
        }

        private void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
