using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.BL.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _unitOfWork.GetUserRepository().GetAll();
            var usersList = users.ToList();
            var returnDto =  _mapper.Map<List<UserDto>>(usersList);
            return returnDto;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _unitOfWork.GetUserRepository().GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
