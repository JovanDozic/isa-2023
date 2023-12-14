﻿using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using QRCoder;
using static QRCoder.PayloadGenerator;
using System.Reflection.Emit;
using static System.Runtime.CompilerServices.RuntimeHelpers;

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

            if(result != null)
            {
                await CreateQRCodeForAppointment(result);
            }

            return "Appointment created successfully, QR code is sent to your email";
        }

        private async Task<string> CreateQRCodeForAppointment(AppointmentDto appointment)
        {
            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            //QRCodeData QrCodeInfo = qRGenerator.CreateQrCode(, QRCodeGenerator.ECCLevel.Q);
            return null;
        }
    }
}
