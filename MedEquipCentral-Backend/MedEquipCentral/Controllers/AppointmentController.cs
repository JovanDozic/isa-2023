using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<AppointmentDto> AddAppointment(AppointmentDto appointment)
        {
            return await _appointmentService.AddAppointment(appointment);
        }

        [HttpGet("getFreeAppointmentsForCompany/{companyId:int}")]
        public async Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId)
        {
            return await _appointmentService.GetFreeAppointmentsForCompany(companyId);
        }

        [HttpPost("createExtraordinaryAppointment")]
        public async Task<string> CreateExtraordinaryAppointment(AppointmentDto dataIn)
        {
            return await _appointmentService.CreateExtraordinaryAppointment(dataIn);
        }
    }
}
