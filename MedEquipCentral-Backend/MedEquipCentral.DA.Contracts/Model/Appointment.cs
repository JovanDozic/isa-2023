﻿using MedEquipCentral.DA.Contracts.Shared;
using System.ComponentModel.DataAnnotations.Schema;

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
        public User? Buyer { get; set; }
        public List<int>? EquipmentIds { get; set; }
        [ForeignKey("EquipmentId")]
        public List<Equipment>? Equipment { get; set; }

        public Appointment(DateTime startTime, int duration, int companyId, string adminName, string adminSurname, int adminId, int buyerId, User buyer, List<int>? equipmentIds, List<Equipment>? equipment)
        {
            StartTime = startTime;
            Duration = duration;
            CompanyId = companyId;
            AdminName = adminName;
            AdminSurname = adminSurname;
            AdminId = adminId;
            BuyerId = buyerId;
            Buyer = buyer;
            EquipmentIds = equipmentIds;
            Equipment = equipment;
        }
    }
}
