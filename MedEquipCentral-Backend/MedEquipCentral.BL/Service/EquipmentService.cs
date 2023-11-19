using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;

namespace MedEquipCentral.BL.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<EquipmentDto> GetAll()
        {
            var equipment = _unitOfWork.GetEquipmentRepository().GetAll();
            return _mapper.Map<List<EquipmentDto>>(equipment);
        }

        public async Task<List<EquipmentDto>> GetAllForCompany(int companyId)
        {
            var equipment = await _unitOfWork.GetEquipmentRepository().GetAllForCompany(companyId);
            return _mapper.Map<List<EquipmentDto>>(equipment);
        }
    }
}
