using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;
using System.Globalization;

namespace MedEquipCentral.BL.Mapper
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<LocationDto, Location>().ReverseMap();

            CreateMap<AppointmentDto, Appointment>()
                .ForMember(dest => dest.StartTime, opt =>
                    opt.MapFrom(src => DateTime.ParseExact(src.StartTime, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture)));
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.StartTime, opt =>
                    opt.MapFrom(src => src.StartTime.ToLongDateString() + "\t at " + src.StartTime.ToLongTimeString()));
        }
    }
}
