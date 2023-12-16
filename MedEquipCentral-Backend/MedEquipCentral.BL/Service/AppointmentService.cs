using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using QRCoder;
using static QRCoder.PayloadGenerator;
using System.Reflection.Emit;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using IronBarCode;

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

        public async void CreateQRCodeForAppointment(AppointmentDto appointmentDto)
        {
            /*List<Task<Equipment>> equipments = new List<Task<Equipment>>();
            foreach (var id in appointmentDto.EquipmentIds)
            {
                equipments.Add(_unitOfWork.GetEquipmentRepository().GetByIdAsync(id));
            }*/
            var company = await _unitOfWork.GetCompanyRepository().GetByIdAsync(appointmentDto.CompanyId);
            var appointment = $"Appointment Id:\t{appointmentDto.Id}\nStart time:\t{appointmentDto.StartTime}\nDuration:\t{appointmentDto.Duration}\nCompany:\t\nAdmin:\t{appointmentDto.AdminSurname} {appointmentDto.AdminName}\nEquipment:\t";
            QRCodeLogo qrCodeLogo = new QRCodeLogo("C:\\Users\\mbovan\\Desktop\\ISA\\isa-2023\\favicon.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo(appointment, qrCodeLogo);
            myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkBlue);
            //myQRCodeWithLogo.SaveAsPng("C:\\Users\\mbovan\\Desktop\\ISA\\isa-2023\\myQRWithLogo.png");
            myQRCodeWithLogo.SaveAsHtmlFile("C:\\Users\\mbovan\\Desktop\\ISA\\isa-2023\\myQRWithLogo.html");
        }
        private async Task<string> CreateQRCodeForAppointment(int appointmentId)
        {
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
