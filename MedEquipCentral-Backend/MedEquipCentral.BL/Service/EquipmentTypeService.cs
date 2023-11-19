using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;

namespace MedEquipCentral.BL.Service
{
    public class EquipmentTypeService : IEquipmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<EquipmentTypeDto> GetAll()
        {
            var types = _unitOfWork.GetEquipmentTypeRepository().GetAll();
            return _mapper.Map<List<EquipmentTypeDto>>(types);
        }
    }
}
