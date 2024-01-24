using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.BL.Mapper
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentDto, Appointment>().ReverseMap();
        }
    }
}
