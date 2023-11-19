using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

        [HttpGet("getById/{id}")]
        public async Task<UserDto> Get(int id) 
        {
            return await _userService.GetById(id);
        }

        [HttpGet("getAllByCompanyId/{companyId:int}")]
        public async Task<List<UserDto>> GetCompanyAdmins(int companyId)
        {
            return await _userService.GetCompanyAdmins(companyId);
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

    }
}
