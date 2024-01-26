namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IMailKitService
    {
        public bool SendPickupConfirmEmail(string emailTo);
    }
}
