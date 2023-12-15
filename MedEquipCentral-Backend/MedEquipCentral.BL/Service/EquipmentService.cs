using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;

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

        public async Task<EquipmentDto> Add(EquipmentDto equipmentDto)
        {
            var equipmentEntity = _mapper.Map<Equipment>(equipmentDto);
            equipmentEntity.Company = null;
            equipmentEntity.Type = null;
            var equipment = await _unitOfWork.GetEquipmentRepository().Add(equipmentEntity);
            await _unitOfWork.Save();
            return _mapper.Map<EquipmentDto>(equipment.Entity);
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

        public async Task<PagedResult<EquipmentDto>> Search(EquipmentPagedIn dataIn)
        {
            var result = await _unitOfWork.GetEquipmentRepository().GetAllBySearch(dataIn);
            List<EquipmentDto> resultDto = _mapper.Map<List<EquipmentDto>>(result);

            return new PagedResult<EquipmentDto>
            {
                Result = resultDto,
                Count = resultDto.Count
            };
        }

        public async Task<EquipmentDto> Update(EquipmentDto equipmentDto)
        {
            var equipmentEntity = _mapper.Map<Equipment>(equipmentDto);
            equipmentEntity.Company = null;
            equipmentEntity.Type = null;
            var equipment = _unitOfWork.GetEquipmentRepository().Update(equipmentEntity);
            await _unitOfWork.Save();
            return _mapper.Map<EquipmentDto>(equipment);
        }

        public async Task<bool> Delete(int equipmentId)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetAllForEquipment(equipmentId);
            if(appointments.Count == 0) //Prosiriti ovu logiku kada se doda da rezervacija nije pokupljena
            {
                var isDeleted = await _unitOfWork.GetEquipmentRepository().Delete(equipmentId);
                if (isDeleted)
                {
                    await _unitOfWork.Save();
                    return true;
                }
            }

            return false;
        }
    }
}
