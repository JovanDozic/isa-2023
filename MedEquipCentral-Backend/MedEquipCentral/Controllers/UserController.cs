using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getById/{id:int}")]
        public async Task<UserDto> Get(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet("getCompanyAdmins/{companyId:int}")]
        public async Task<List<UserDto>> GetCompanyAdmins(int companyId)
        {
            return await _userService.GetCompanyAdmins(companyId);
        }

        [HttpGet("getOtherCompanyAdmins/{companyId:int}/{adminId:int}")]
        public async Task<List<UserDto>> GetOtherCompanyAdmins(int companyId, int adminId)
        {
            return await _userService.GetOtherCompanyAdmins(companyId, adminId);
        }

        [HttpPut("update")]
        public async Task<UserDto> Update(UserDto user)
        {
            return await _userService.Update(user);
        }

        [HttpPatch("{userId:int}/removeFromCompany")]
        public async Task RemoveFromCompany(int userId)
        {
            await _userService.RemoveFromCompany(userId);
        }

        [HttpPatch("{userId:int}/addToCompany/{companyId:int}")]
        public async Task AddToCompany(int userId, int companyId)
        {
            await _userService.AddToCompany(userId, companyId);
        }

        [HttpGet("getAllRegistered")]
        public async Task<List<UserDto>> GetAllRegistered()
        {
            return await _userService.GetAllRegistered();
        }

        [HttpPatch("{userId:int}/addSystemAdmin")]
        public async Task AddSystemAdmin(int userId)
        {
            await _userService.AddSystemAdmin(userId);
        }

    }
}
