using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var appointment = await _unitOfWork.GetAppointmentRepository().Add(_mapper.Map<Appointment>(appointmentDto));
            await _unitOfWork.Save();
            return _mapper.Map<AppointmentDto>(appointment.Entity);

        }

        public async Task<List<AppointmentDto>> GetFreeAppointmentsForCompany(int companyId)
        {
            var appointments = _unitOfWork.GetAppointmentRepository().GetAll().Result.Where(x => x.CompanyId == companyId && x.EquipmentId == null).ToList();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
    }
}
