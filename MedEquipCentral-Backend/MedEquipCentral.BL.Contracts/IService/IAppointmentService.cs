using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId);
        Task<string> CreateExtraordinaryAppointment(AppointmentDto dataIn);
        Task<List<AppointmentDto>> GetCompanyAppointments(int companyId);
        Task<AppointmentDto> GetById(int id);
        Task<PagedResult<AppointmentDto>> GetAllUsersAppointments(AppointmentPagedIn dataIn);
        Task<string> CreateAppointment(AppointmentDto dataIn);
    }
}
