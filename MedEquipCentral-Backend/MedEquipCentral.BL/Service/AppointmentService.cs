using AutoMapper;
using IronBarCode;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using System;

namespace MedEquipCentral.BL.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IMailKitService _mailKitService;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, IMailKitService mailKitService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _mailKitService = mailKitService;
        }

        private async Task<AppointmentDto> AddAppointment(AppointmentDto appointmentDto)
        {
            return await ValidateAndSave(appointmentDto);
        }

        private async Task<AppointmentDto> ValidateAndSave(AppointmentDto appointmentDto)
        {
            var company = await _unitOfWork.GetCompanyRepository().GetByIdAsync(appointmentDto.CompanyId);
            var appointmentTime = TimeOnly.FromDateTime(appointmentDto.StartTime);

            //TODO
            if (true/*appointmentTime >= company.StartTime && appointmentTime <= company.EndTime && appointmentTime.AddMinutes(appointmentDto.Duration) <= company.EndTime*/)
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

        public async Task<string> CreateAppointment(AppointmentDto dataIn)
        {
            var result = await AddAppointment(dataIn);

            if (result != null)
            {

                await CreateQRCodeForAppointment(result);
            }

            return "Appointment created successfully, QR code is sent to your email";
        }
        private async Task<string> CreateQRCodeForAppointment(AppointmentDto appointmentDto)
        {
            var count = _unitOfWork.GetAppointmentRepository().GetAll().Result.Count();
            var user = await _unitOfWork.GetUserRepository().GetByIdAsync((int)appointmentDto.BuyerId);
            CreateQrCode(appointmentDto, count);
            await _emailService.SendAppointmentConfirmationEmail(new UserEmailOptionsDto
            {
                ToEmail = user.Email,
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.Name),
                    new KeyValuePair<string, string>("{{Id}}", appointmentDto.Id.ToString()),
                }
            }, $"C:\\Users\\mbovan\\Desktop\\ISA\\isa-2023\\reservation{count}.png");
            return null;
        }

        private static void CreateQrCode(AppointmentDto appointmentDto, int count)
        {
            //TODO ispis liste doraditi
            //TODO uraditi relativne putanje
            var appointment = $"http://localhost:4200/appointment-details/{count}";
            QRCodeLogo qrCodeLogo = new QRCodeLogo("C:\\Users\\mbovan\\Desktop\\ISA\\isa-2023\\favicon.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo(appointment, qrCodeLogo);
            myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkBlue);
            myQRCodeWithLogo.SaveAsPng($"C:\\Users\\mbovan\\Desktop\\ISA\\isa-2023\\reservation{count}.png");
        }

        public async Task<List<AppointmentDto>> GetCompanyAppointments(int companyId)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetAllByCompany(companyId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> GetById(int appointmentId)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetById(appointmentId);

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return appointmentDto;
        }

        public async Task<PagedResult<AppointmentDto>> GetAllUsersAppointments(AppointmentPagedIn dataIn)
        {
            var appointments = !dataIn.IsAdmin
                ? await _unitOfWork.GetAppointmentRepository().GetAllUsersAppointments(dataIn)
                : await _unitOfWork.GetAppointmentRepository().GetAllAdminsAppointments(dataIn.UserId);

            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments);

            return new PagedResult<AppointmentDto>()
            {
                Result = appointmentsDto
            };
        }

        public async Task<bool> FlagAs(int appointmentId, Contracts.DTO.AppointmentStatus status)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetById(appointmentId);
            if (appointment is null)
            {
                return false;
            }
            appointment.Status = (DA.Contracts.Model.AppointmentStatus?)status;
            await _unitOfWork.Save();

            if (status == Contracts.DTO.AppointmentStatus.PROCESSED)
            {
                if (appointment.BuyerId is null)
                {
                    return false;
                }
                var user = await _unitOfWork.GetUserRepository().GetByIdAsync((int)appointment.BuyerId);
                _mailKitService.SendPickupConfirmEmail(user.Email);
            }

            return true;
        }

        public async Task<string> CancelAppointment(int appointmentId)
        {
            var appointmentDb = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(appointmentId);

            var timeDifference = DateTime.Now.Subtract(appointmentDb.StartTime).TotalHours;

            if(timeDifference > 24)
            {
                await _unitOfWork.GetAppointmentRepository().Remove(appointmentDb);
                return "Appointment is canceled successfully";
            }
            else
            {
                return "Appointment is in 24h range so you cant cancel it";
            }
        }

        public async Task<AppointmentDto> Update(AppointmentDto appointmentDto)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(appointmentDto.Id);
            appointment.IsCollected= appointmentDto.IsCollected;
            appointment.EquipmentIds= appointmentDto.EquipmentIds;
            appointment.BuyerId= appointmentDto.BuyerId;

            _unitOfWork.GetAppointmentRepository().Update(appointment);
            await _unitOfWork.Save();
            return appointmentDto;
        }

        public async Task SendCollectionConfirmationEmail(AppointmentDto appointmentDto)
        {
            await _emailService.SendCollectionConfirmationEmail(new UserEmailOptionsDto
            {
                ToEmail = appointmentDto.Buyer.Email,
                Placeholders = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("{{CompanyName}}", appointmentDto.Company.Name),
            }
            });
        }

        public async Task<List<AppointmentDto>> GetHistory(AppointmentPagedIn dataIn)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetHistory(dataIn);

            var appointmentDtos = _mapper.Map <List<AppointmentDto>>(appointments);

            return appointmentDtos;
        }
    }
}
