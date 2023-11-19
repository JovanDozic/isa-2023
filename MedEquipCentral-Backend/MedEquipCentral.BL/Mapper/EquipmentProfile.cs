using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.BL.Mapper
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<EquipmentTypeDto, EquipmentType>().ReverseMap();
            CreateMap<EquipmentDto, Equipment>().ReverseMap();
        }
    }
}
