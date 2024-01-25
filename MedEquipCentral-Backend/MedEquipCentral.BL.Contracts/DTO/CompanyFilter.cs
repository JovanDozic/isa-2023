using System;
namespace MedEquipCentral.BL.Contracts.DTO
{
    public class CompanyFilter
    {
        public int Rating { get; set; }
        public string Search { get; set; }
        public string SortBy { get; set; }
        public bool IsAsc { get; set; }
    }
}
