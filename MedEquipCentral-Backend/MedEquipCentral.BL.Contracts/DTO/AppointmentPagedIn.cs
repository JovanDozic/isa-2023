﻿namespace MedEquipCentral.BL.Contracts.DTO
{
    public class AppointmentPagedIn
    {
        public PageInfo PageInfo { get; set; }
        public int UserId { get; set; }
        public bool IsAdmin {  get; set; }
        public string SortBy { get; set; }
        public bool IsAsc { get; set; }
    }
}
