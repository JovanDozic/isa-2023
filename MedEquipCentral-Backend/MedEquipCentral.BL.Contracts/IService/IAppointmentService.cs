using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId);
        Task<string> CreateAppointment(AppointmentDto dataIn);
        Task<List<AppointmentDto>> GetCompanyAppointments(int companyId);
        Task<AppointmentDto> GetById(int id);
        Task<PagedResult<AppointmentDto>> GetAllUsersAppointments(AppointmentPagedIn dataIn);
        Task<bool> FlagAs(int appointmentId, AppointmentStatus status);
        Task<AppointmentDto> Update(AppointmentDto appointment);
        Task SendCollectionConfirmationEmail(AppointmentDto appointmentDto);
        Task<string> CancelAppointment(int appointmentId);
        Task<List<AppointmentDto>> GetHistory(AppointmentPagedIn dataIn);
        Task<List<QrCodeDto>> GetQrCodes(QrCodeDataIn dataIn);
    }
}
