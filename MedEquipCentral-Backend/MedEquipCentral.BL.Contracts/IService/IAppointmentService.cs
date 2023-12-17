using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId);
        Task<string> CreateAppointment(AppointmentDto dataIn);
        Task<List<AppointmentDto>> GetCompanyAppointments(int companyId);
        Task<AppointmentDto> GetById(int id);
        Task<PagedResult<AppointmentDto>> GetAllUsersAppointments(AppointmentPagedIn dataIn);
        Task<string> CreateAppointment(AppointmentDto dataIn);
    }
}
