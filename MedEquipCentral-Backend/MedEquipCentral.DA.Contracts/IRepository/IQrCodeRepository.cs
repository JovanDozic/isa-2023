using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Helper;

namespace MedEquipCentral.DA.Contracts.IRepository
{
    public interface IQrCodeRepository : IRepository<QrCode>
    {
        Task<QrCode> GetByAppointmentId(int appointmentId);
        Task<List<QrCode>> GetByUserId(QrCodeDataIn dataIn);
    }
}
