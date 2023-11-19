using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.BL.Mapper
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<AppointmentDto, Appointment>().ReverseMap();
        }
    }
}
