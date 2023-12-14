using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [Route("api/equipment")]
    [ApiController]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("getAll")]
        public List<EquipmentDto> GetAll()
        {
            return _equipmentService.GetAll();
        }

        [HttpGet("getAllForCompany/{companyId:int}")]
        public async Task<List<EquipmentDto>> GetAllForCompany(int companyId)
        {
            return await _equipmentService.GetAllForCompany(companyId);
        }

        [HttpPost("search")]
        public async Task<PagedResult<EquipmentDto>> Search(EquipmentPagedIn dataIn)
        {
            return await _equipmentService.Search(dataIn);
        }

        [HttpPost]
        public async Task<EquipmentDto> Add(EquipmentDto equipmentDto)
        {
            return await _equipmentService.Add(equipmentDto);
        }
    }
}
