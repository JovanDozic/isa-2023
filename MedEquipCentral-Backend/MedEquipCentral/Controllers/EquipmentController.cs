using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPut]
        public async Task<EquipmentDto> Update(EquipmentDto equipmentDto)
        {
            return await _equipmentService.Update(equipmentDto);
        }

        [HttpDelete("{equipmentId:int}")]
        public async Task<bool> Delete(int equipmentId)
        {
            return await _equipmentService.Delete(equipmentId);
        }

        [HttpGet("getById/{id:int}")]
        public async Task<EquipmentDto> GetById(int id)
        {
            return await _equipmentService.GetById(id);
        }

        [HttpPatch("reduceQuantityOfCollected/{appointmentId:int}")]
        public async Task<List<EquipmentDto>> ReduceQuantity(int appointmentId)
        {
            return await _equipmentService.ReduceQuantity(appointmentId);
        }
        [HttpGet("startDelivery")] // /*/{startLat:float}/{startLon:float}/{endLat:float}/{endLon:float}*/
        public Task<bool> StartDelivery(/*float startLat, float startLon, float endLat, float endLon*/)
        {
            return _equipmentService.StartDelivery();
        }

        [HttpGet("getMessage")]
        public List<string> GetMessage()
        {
            return _equipmentService.GetMessage();
        }
    }
}
