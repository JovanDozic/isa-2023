using MedEquipCentral.BL.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> AddAppointment(AppointmentDto appointment);
        Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId);
        Task<string> CreateExtraordinaryAppointment(AppointmentDto dataIn);
        Task<List<AppointmentDto>> GetCompanyAppointments(int companyId);
    }
}
