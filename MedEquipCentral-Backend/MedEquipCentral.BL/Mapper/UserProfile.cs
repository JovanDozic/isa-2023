using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.BL.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        { 
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
