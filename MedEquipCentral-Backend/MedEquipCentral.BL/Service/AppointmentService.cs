using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using QRCoder;

namespace MedEquipCentral.BL.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> AddAppointment(AppointmentDto appointmentDto)
        {
            return await ValidateAndSave(appointmentDto);
        }

        private async Task<AppointmentDto> ValidateAndSave(AppointmentDto appointmentDto)
        {
            var company = await _unitOfWork.GetCompanyRepository().GetByIdAsync(appointmentDto.CompanyId);
            var appointmentTime = TimeOnly.FromDateTime(appointmentDto.StartTime);

            if (appointmentTime >= company.StartTime && appointmentTime <= company.EndTime && appointmentTime.AddMinutes(appointmentDto.Duration) <= company.EndTime)
            {
                var appointment = _mapper.Map<Appointment>(appointmentDto);
                await _unitOfWork.GetAppointmentRepository().Add(appointment);
                await _unitOfWork.Save();
                return appointmentDto;
            }

            return null; //If validation fails 
            //TODO: Dodati bolji nacin rada sa ovom metodom
        }

        public async Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetFreeAppointments(companyId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<string> CreateExtraordinaryAppointment(AppointmentDto dataIn)
        {
            var result = await AddAppointment(dataIn);

            if (result != null)
            {

                await CreateQRCodeForAppointment(result.Id);
            }

            return "Appointment created successfully, QR code is sent to your email";
        }

        private async Task<string> CreateQRCodeForAppointment(int appointmentId)
        {
            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = qRGenerator.CreateQrCode($"{appointmentId}", QRCodeGenerator.ECCLevel.Q);
            return null;
        }

        public async Task<List<AppointmentDto>> GetCompanyAppointments(int companyId)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetAllByCompany(companyId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> GetById(int appointmentId)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(appointmentId);

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return appointmentDto;
        }

        public async Task<PagedResult<AppointmentDto>> GetAllUsersAppointments(AppointmentPagedIn dataIn)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetAllUsersAppointments(dataIn);

            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments);

            return new PagedResult<AppointmentDto>()
            {
                Result = appointmentsDto
            };
        }
    }
}
