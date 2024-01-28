using AutoMapper;
using IronBarCode;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Helper;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using AppointmentStatus = MedEquipCentral.BL.Contracts.DTO.AppointmentStatus;

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
            var appointmentTime = TimeOnly.FromDateTime(appointmentDto.StartTime);
            if(appointmentDto.AdminId == 0)
            {
                var companyAdmins = _unitOfWork.GetUserRepository().GetAllByCompanyId(appointmentDto.CompanyId);
                foreach(var companyAdmin in companyAdmins)
                {
                    var appointments = await _unitOfWork.GetAppointmentRepository().GetAllAdminsAppointments(companyAdmin.Id);
                    if(appointments != null)
                    {
                        foreach(var appointment in appointments)
                        {
                            if(appointmentDto.StartTime.AddMinutes(appointmentDto.Duration) <= appointment.StartTime || appointment.StartTime.AddMinutes(appointment.Duration) < appointmentDto.StartTime)
                            {
                                appointmentDto.AdminId = companyAdmin.Id;
                                var appo = _mapper.Map<Appointment>(appointmentDto);
                                await _unitOfWork.GetAppointmentRepository().Add(appo);
                                await _unitOfWork.Save();
                                return appointmentDto;
                            }
                        }
                    }
                    appointmentDto.AdminId = companyAdmin.Id;
                    var app = _mapper.Map<Appointment>(appointmentDto);
                    await _unitOfWork.GetAppointmentRepository().Add(app);
                    await _unitOfWork.Save();
                    return appointmentDto;
                }
            }
            var company = await _unitOfWork.GetCompanyRepository().GetByIdAsync(appointmentDto.CompanyId);

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
            var list = await _unitOfWork.GetAppointmentRepository().GetAll();
            var count = list.Count();
            var user = await _unitOfWork.GetUserRepository().GetByIdAsync(appointmentDto.BuyerId.Value);
            CreateQrCode(appointmentDto, count);
            await _emailService.SendAppointmentConfirmationEmail(new UserEmailOptionsDto
            {
                ToEmail = user.Email,
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.Name),
                    new KeyValuePair<string, string>("{{Id}}", appointmentDto.Id.ToString()),
                }
            }, $"../../../QRCodes/reservation{count}.png");

            var path = $"reservation{count}.png";

            var qrCode = new QrCode();
            qrCode.AdminId = appointmentDto.AdminId;
            qrCode.BuyerId = appointmentDto.BuyerId.Value;
            qrCode.AppointmentId = count;
            qrCode.AppointmentStatus = (DA.Contracts.Model.AppointmentStatus)AppointmentStatus.NEW;
            qrCode.Path = path;
            await _unitOfWork.GetQrCodeRepository().Add(qrCode);
            await _unitOfWork.Save();
            return null;
        }

        private static void CreateQrCode(AppointmentDto appointmentDto, int count)
        {
            //TODO ispis liste doraditi
            //TODO uraditi relativne putanje
            var appointment = $"http://localhost:4200/appointment-details/{count}";
            QRCodeLogo qrCodeLogo = new QRCodeLogo("../../favicon.png");
            GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo(appointment, qrCodeLogo);
            myQRCodeWithLogo.ResizeTo(500, 500).SetMargins(10).ChangeBarCodeColor(Color.DarkBlue);
            myQRCodeWithLogo.SaveAsPng($"../../QRCodes/reservation{count}.png");
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

        public async Task<bool> FlagAs(int appointmentId, AppointmentStatus status)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetById(appointmentId);
            if (appointment is null)
            {
                return false;
            }
            appointment.Status = (DA.Contracts.Model.AppointmentStatus?)status;

            var qrCode = await _unitOfWork.GetQrCodeRepository().GetByAppointmentId(appointmentId);
            qrCode.AppointmentStatus = (DA.Contracts.Model.AppointmentStatus)status;
            _unitOfWork.GetQrCodeRepository().Update(qrCode);

            await _unitOfWork.Save();

            if (status == AppointmentStatus.PROCESSED)
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
            var appointment = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(appointmentId);
            appointment.Status = DA.Contracts.Model.AppointmentStatus.CANCELLED;

            var user = await _unitOfWork.GetUserRepository()?.GetByIdAsync((int)appointment.BuyerId);

            var qrCode = await _unitOfWork.GetQrCodeRepository().GetByAppointmentId(appointmentId);
            qrCode.AppointmentStatus = (DA.Contracts.Model.AppointmentStatus)AppointmentStatus.CANCELLED;

            if (timeDifference > 24)
            var timeDifference = DateTime.Now.Subtract(appointment.StartTime).TotalHours;
            
            if(timeDifference > 24)
            {
                user.PenalPoints += 1;
                _unitOfWork.GetAppointmentRepository().Update(appointment);
                _unitOfWork.GetUserRepository().Update(user);
                await _unitOfWork.Save();
                return "Appointment canceled successfully";
            }
            else
            {
                user.PenalPoints += 2;
                _unitOfWork.GetAppointmentRepository().Update(appointment);
                _unitOfWork.GetUserRepository().Update(user);
                await _unitOfWork.Save();
                return "Appointment canceled successfully";
            }
        }

        public async Task<AppointmentDto> Update(AppointmentDto appointmentDto)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(appointmentDto.Id);
            appointment.Status = (DA.Contracts.Model.AppointmentStatus?)appointmentDto.Status;
            appointment.EquipmentIds= appointmentDto.EquipmentIds;
            appointment.BuyerId= appointmentDto.BuyerId;

            var qrCode = await _unitOfWork.GetQrCodeRepository().GetByAppointmentId(appointmentDto.Id);
            qrCode.BuyerId = appointmentDto.BuyerId;
            _unitOfWork.GetQrCodeRepository().Update(qrCode);

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

        public async Task<List<QrCodeDto>> GetQrCodes(QrCodeDataIn dataIn)
        {
            var qrCodes = await _unitOfWork.GetQrCodeRepository().GetByUserId(dataIn);

            var qrCodeDtos = _mapper.Map<List<QrCodeDto>>(qrCodes);

            return qrCodeDtos;
        }
    }
}
