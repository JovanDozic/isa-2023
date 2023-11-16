using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.BL.Mapper
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<LocationDto, Location>().ReverseMap();
        }
    }
}
