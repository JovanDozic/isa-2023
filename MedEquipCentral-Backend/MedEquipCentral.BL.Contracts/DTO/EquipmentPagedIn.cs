
namespace MedEquipCentral.BL.Contracts.DTO
{
    public class EquipmentPagedIn
    {
        public PageInfo PageInfo { get; set; }
        public int CompanyId { get; set; }
        public string Search { get; set; }
    }
}
