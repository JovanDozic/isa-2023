using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [EnableCors("_mySpecificOrigins")]
    [Route("api/appointment")]
    [ApiController] 
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet("getFreeAppointmentsForCompany/{companyId:int}")]
        public async Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId)
        {
            return await _appointmentService.GetFreeAppointmentsForCompany(companyId);
        }

        [HttpPost("createAppointment")]
        public async Task<string> CreateAppointment(AppointmentDto dataIn)
        {
            return await _appointmentService.CreateAppointment(dataIn);
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

        [HttpPost("sendCollectionConfirmationEmail")]
        public async Task SendCollectionConfirmationEmail(AppointmentDto appointmentDto)
        {
            await _appointmentService.SendCollectionConfirmationEmail(appointmentDto);
        }

        [HttpPut("update")]
        public async Task<AppointmentDto> Update(AppointmentDto appointment)
        {
            return await _appointmentService.Update(appointment);
        }

        [HttpPatch("cancelAppointment/{appointmentId:int}")]
        public async Task<string> CancelAppointment(int appointmentId)
        {
            return await _appointmentService.CancelAppointment(appointmentId);
        }

        [HttpPut("flagAsExpired/{appointmentId:int}")]
        public async Task<bool> FlagAsExpired(int appointmentId)
        {
            return await _appointmentService.FlagAs(appointmentId, AppointmentStatus.EXPIRED);
        }

        [HttpPut("flagAsPickedUp/{appointmentId:int}")]
        public async Task<bool> FlagAsPickedUp(int appointmentId)
        {
            return await _appointmentService.FlagAs(appointmentId, AppointmentStatus.PROCESSED);
        }

        [HttpPut("flagAsCancelled/{appointmentId:int}")]
        public async Task<bool> FlagAsCancelled(int appointmentId)
        {
            return await _appointmentService.FlagAs(appointmentId, AppointmentStatus.CANCELLED);
        }

        [HttpPost("getHistory")]
        public async Task<List<AppointmentDto>> GetHistory([FromBody]AppointmentPagedIn dataIn)
        {
            return await _appointmentService.GetHistory(dataIn);
        }

    }
}
