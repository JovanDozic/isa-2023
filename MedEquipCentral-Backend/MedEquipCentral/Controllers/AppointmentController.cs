using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
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

        [HttpPost("qr")]
        public async void TestQrCode(AppointmentDto appointmentDto)
        {
            _appointmentService.CreateQRCodeForAppointment(appointmentDto);
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

        [HttpGet("getCompanyAppointments/{companyId:int}")]
        public async Task<List<AppointmentDto>> GetCompanyAppointments(int companyId)
        {
            return await _appointmentService.GetCompanyAppointments(companyId);
        }

        [HttpGet("getById/{appointmentId:int}")]
        public async Task<AppointmentDto> GetById(int appointmentId)
        {
            return await _appointmentService.GetById(appointmentId);
        }

        [HttpPost("getAllUsersAppointments")]
        public async Task<PagedResult<AppointmentDto>> GetAllUsersAppointments(AppointmentPagedIn dataIn)
        {
            return await _appointmentService.GetAllUsersAppointments(dataIn);
        }
    }
}
