using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [Route("api/equipmentTypes")]
    [ApiController]
    public class EquipmentTypeController : Controller
    {
        private readonly IEquipmentTypeService _equipmentTypeService;

        public EquipmentTypeController(IEquipmentTypeService equipmentTypeService)
        {
            _equipmentTypeService = equipmentTypeService;
        }

        [HttpGet("getAll")]
        public List<EquipmentTypeDto> GetAll()
        {
            return _equipmentTypeService.GetAll();
        }
    }
}
