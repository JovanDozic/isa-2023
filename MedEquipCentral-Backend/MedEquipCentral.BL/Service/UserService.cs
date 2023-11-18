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

        public async Task<List<UserDto>> GetCompanyAdmins(int companyId)
        {
            var users = await _unitOfWork.GetUserRepository().GetAll();
            var companyAdminsDto = users.ToList().Where(x => x.CompanyId == companyId);
            return _mapper.Map<List<UserDto>>(companyAdminsDto);
        }

        public async Task<UserDto> Update(UserDto user)
        {
            //var userToUpdate = _mapper.Map<User>(user);
            var userToUpdate = new User(user.Email, user.Password, user.Name, user.Surname, user.City, user.Country, user.Phone, user.Job, user.CompanyInfo, UserRole.Registered);
            userToUpdate.Id = user.Id;
            var updatedUser = _unitOfWork.GetUserRepository().Update(userToUpdate);
            await _unitOfWork.Save();
            var retVal = _mapper.Map<UserDto>(updatedUser);
            return retVal;
        }

        public async Task RemoveFromCompany(int userId)
        {
            var user = await _unitOfWork.GetUserRepository().GetByIdAsync(userId);
            user.CompanyId = null;
            user.Role = UserRole.Registered;
            _unitOfWork.GetUserRepository().Update(user);
            await _unitOfWork.Save();
        }

        public async Task AddToCompany(int userId, int companyId)
        {
            var user = await _unitOfWork.GetUserRepository().GetByIdAsync(userId);
            user.CompanyId = companyId;
            user.Role = UserRole.Company_Admin;
            _unitOfWork.GetUserRepository().Update(user);
            await _unitOfWork.Save();
        }

        public async Task<List<UserDto>> GetAllRegistered()
        {
            var users = (await _unitOfWork.GetUserRepository().GetAll()).Where(x => x.Role == UserRole.Registered);
            return _mapper.Map<List<UserDto>>(users);
        }

        
    }
}
