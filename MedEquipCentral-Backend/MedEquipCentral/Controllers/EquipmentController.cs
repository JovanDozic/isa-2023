using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
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

        [HttpGet("getAllForCompany/{companyId:int}")]
        public async Task<List<EquipmentDto>> GetAllForCompany(int companyId)
        {
            return await _equipmentService.GetAllForCompany(companyId);
        }
    }
}
