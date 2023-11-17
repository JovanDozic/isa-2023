using System;
namespace MedEquipCentral.BL.Contracts.DTO
{
    public class CompanyFilter
    {
        public int Rating { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Search { get; set; }
    }
}
