namespace MedEquipCentral.BL.Contracts.DTO
{
    public class QrCodeDataIn
    {
        public PageInfo PageInfo { get; set; }
        public int UserId { get; set; }
        public string FilterBy { get; set; }
    }
}
